using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading;
using Grpc.Core;
using Engine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace engine_controller
{
    class Program
    {
        #region variables
        private static readonly AutoResetEvent waitHandle = new AutoResetEvent(false);
        private static string hostname;
        private static string user;
        private static string pass;
        private static string engine_hostname;
        private static int engine_port;
        private static string grpc_connstring;

        #endregion
        static void Main(string[] args)
        {
            _getConfigurationSettings();

            //Creating connection to rabbitmq queue
            var factory = new ConnectionFactory() { HostName = hostname, UserName=user, Password=pass };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "rpc_queue", durable: false,
                exclusive: false, autoDelete: false, arguments: null);
                channel.BasicQos(0, 1, false);
                var consumer = new EventingBasicConsumer(channel);
                channel.BasicConsume(queue: "rpc_queue",
                autoAck: false, consumer: consumer);
                Console.WriteLine(" [x] Awaiting RPC requests");

                consumer.Received += (model, ea) =>
                {
                    string response = null;

                    var body = ea.Body;
                    var props = ea.BasicProperties;
                    var replyProps = channel.CreateBasicProperties();
                    replyProps.CorrelationId = props.CorrelationId;

                    try
                    {
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" receiving ({0})", message);

                        //Do the actual job - calling the engine
                        EngineReply reply = _callEngine(message);
                    
                        response = $"'{message}' processed. Result: {reply.ResponseMessage}. Correlation Id: {replyProps.CorrelationId}.";
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" [.] " + e.Message);
                        response = "";
                    }
                    finally
                    {
                        var responseBytes = Encoding.UTF8.GetBytes(response);
                        channel.BasicPublish(exchange: "", routingKey: props.ReplyTo,
                        basicProperties: replyProps, body: responseBytes);
                        channel.BasicAck(deliveryTag: ea.DeliveryTag,
                        multiple: false);
                    }
                };
                _handleWait();
            }
        }

        private static void _handleWait()
        {
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();

        // Handle Control+C or Control+Break
            Console.CancelKeyPress += (o, e) =>
            {
                Console.WriteLine("Exit");

                // Allow the manin thread to continue and exit...
                waitHandle.Set();
            };

            // Wait
            waitHandle.WaitOne();
        }

        private static EngineReply _callEngine(string message)
        {
            Channel rpcChannel = new Channel(grpc_connstring, ChannelCredentials.Insecure);
            var client = new EngineWork.EngineWorkClient(rpcChannel);

            var reply = client.Execute(new EngineRequest { InputMessage = message});

            // Console.WriteLine("Greeting: " + reply.Message);
            rpcChannel.ShutdownAsync().Wait(); 

            return reply;
       }

        private static void _getConfigurationSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            IConfigurationRoot configuration = builder.Build();
            
            engine_hostname = configuration.GetSection("engineconnection")["hostname"];
            engine_port = int.Parse(configuration.GetSection("engineconnection")["port"]);

            grpc_connstring = $"{engine_hostname}:{engine_port}";
            Console.Write($"grpc connection string: {grpc_connstring}");

            hostname = configuration.GetSection("rabbitmq")["hostname"];
            user = configuration.GetSection("rabbitmq")["user"];
            pass = configuration.GetSection("rabbitmq")["pass"];
        }
    }
}
