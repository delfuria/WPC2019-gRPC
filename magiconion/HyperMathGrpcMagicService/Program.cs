using Grpc.Core;
using MagicOnion;
using MagicOnion.Hosting;
using MagicOnion.Server;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Server
{
    class Program
    {
        static async Task Main(string[] args)
        {  //MyFirstService.Initialize();
            GrpcEnvironment.SetLogger(new Grpc.Core.Logging.ConsoleLogger());

            // setup MagicOnion and option.
            var service = MagicOnionEngine.BuildServerServiceDefinition(isReturnExceptionStackTraceInErrorDetail: true);

            var server = new global::Grpc.Core.Server
            {
                Services = { service },
                Ports = { new ServerPort("localhost", 5001, ServerCredentials.Insecure) }
            };

            // launch gRPC Server.
            server.Start();

            // and wait.
            Console.ReadLine();
        }
    }

}
