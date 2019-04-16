using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class RpcClient
{
    #region variables
    private readonly IConnection connection;
    private readonly IModel channel;
    private readonly string replyQueueName;
    private readonly EventingBasicConsumer consumer;
    private readonly BlockingCollection<string> respQueue = new BlockingCollection<string>();
    private readonly IBasicProperties props;
    private readonly string correlationId;
    private CancellationToken ct;
    #endregion
    
    public RpcClient(string hostname, string user, string pass)
    {
        // var hostname = Environment.GetEnvironmentVariable("rabbitmq_hostname") != null ? Environment.GetEnvironmentVariable("rabbitmq_hostname") : "localhost";
        // var user = Environment.GetEnvironmentVariable("rabbitmq_user") != null ? Environment.GetEnvironmentVariable("rabbitmq_user") : "user";
        // var pass = Environment.GetEnvironmentVariable("rabbitmq_pass") != null ? Environment.GetEnvironmentVariable("rabbitmq_pass") : "NOGJ4yPikc";
        
        // var factory = new ConnectionFactory() { HostName = "104.211.7.11", Port=31118 };
        var factory = new ConnectionFactory() { HostName = hostname, UserName= user, Password = pass};

        connection = factory.CreateConnection();
        channel = connection.CreateModel();
        replyQueueName = channel.QueueDeclare().QueueName;
        consumer = new EventingBasicConsumer(channel);

        props = channel.CreateBasicProperties();
        correlationId = Guid.NewGuid().ToString();
        props.CorrelationId = correlationId;
        props.ReplyTo = replyQueueName;

        consumer.Received += (model, ea) =>
        {
            var body = ea.Body;
            var response = Encoding.UTF8.GetString(body);
            if (ea.BasicProperties.CorrelationId == correlationId)
            {
                respQueue.Add(response);
            }
        };
    }

    public string Call(string message)
    {
        var messageBytes = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish(
            exchange: "",
            routingKey: "rpc_queue",
            basicProperties: props,
            body: messageBytes);

        channel.BasicConsume(
            consumer: consumer,
            queue: replyQueueName,
            autoAck: true);

        //Defining a 5 sec timeout
        CancellationTokenSource cts = new CancellationTokenSource(5000);
        return respQueue.Take(cts.Token); 
    }



    public void Close()
    {
        connection.Close();
    }


}
