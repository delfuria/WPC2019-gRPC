using Grpc.Core;
using MagicOnion;
using MagicOnion.Hosting;
using MagicOnion.HttpGateway.Swagger;
using MagicOnion.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace HyperMathGrpcMagicServiceHost
{    class Program
    {
        static async Task Main(string[] args)
        {
            // setup MagicOnion hosting.
            var magicOnionHost = MagicOnionHost.CreateDefaultBuilder()
                .UseMagicOnion(
                    new MagicOnionOptions(isReturnExceptionStackTraceInErrorDetail: true),
                    new ServerPort("localhost", 5001, ServerCredentials.Insecure))
                .UseConsoleLifetime()
                .Build();

            // NuGet: Microsoft.AspNetCore.Server.Kestrel
            var webHost = new WebHostBuilder()
                .ConfigureServices(collection =>
                {
                // Add MagicOnionServiceDefinition for reference from Startup.
                collection.AddSingleton<MagicOnionServiceDefinition>(magicOnionHost.Services.GetService<MagicOnionHostedServiceDefinition>().ServiceDefinition);
                })
                .UseKestrel()
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5432")
                .Build();

            // Run and wait both.
            await Task.WhenAll(webHost.RunAsync(), magicOnionHost.RunAsync());
        }
    }
}
