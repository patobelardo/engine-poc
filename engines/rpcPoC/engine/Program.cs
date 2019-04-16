// Copyright 2015 gRPC authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Threading.Tasks;
using Grpc.Core;
using Engine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using System.Threading;

namespace Engine
{
    class EngineImpl : EngineWork.EngineWorkBase
    {
        // Server side handler of the Execute RPC
        public override async Task<EngineReply> Execute(EngineRequest request, ServerCallContext context)
        {
            if (request.InputMessage.ToLower() == "error")
            {
                Console.WriteLine($"Generating an error message");
                throw new Exception("Generating an error message");
            }
            Console.WriteLine($"Processing call from {request.InputMessage}");
            await Task.Delay(2000);
            Console.WriteLine($"Processed!");
            return new EngineReply { ResponseMessage = "Doing work " + request.InputMessage };
        }
    }

    class Program
    {
        private static readonly AutoResetEvent waitHandle = new AutoResetEvent(false);

        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            IConfigurationRoot configuration = builder.Build();
            
            var Port = int.Parse(configuration.GetSection("engineconnection")["port"]);

            Server server = new Server
            {
                Services = { EngineWork.BindService(new EngineImpl()) },
                Ports = { new ServerPort("0.0.0.0", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Engine server listening on port " + Port);

            Console.CancelKeyPress += (o, e) =>
            {
                Console.WriteLine("Exit");

                // Allow the manin thread to continue and exit...
                waitHandle.Set();
            };

            // Wait
            waitHandle.WaitOne();

            server.ShutdownAsync().Wait();
        }
    }
}