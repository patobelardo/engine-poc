using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        string hostname;
        string user;
        string pass;
        public WorkController(IConfiguration _configuration)
        {
            hostname = _configuration.GetSection("rabbitmq")["hostname"];
            user = _configuration.GetSection("rabbitmq")["user"];
            pass = _configuration.GetSection("rabbitmq")["pass"];
        }
        [HttpGet]
        public ActionResult<string> DoWork()
        {
            Random rnd = new Random();
            string id = rnd.Next(1,100000).ToString();

            return rpcCall(id);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Do(string id)
        {
            return rpcCall(id);
        }

        private string rpcCall(string id)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            

            var rpcClient = new RpcClient(hostname, user, pass);
            var response = rpcClient.Call(id);
            
            
            stopwatch.Stop();
            rpcClient.Close();
            return $"Sent: {id}; Response: {response}; Elapsed ms: {stopwatch.Elapsed}";

        }
    }
}
