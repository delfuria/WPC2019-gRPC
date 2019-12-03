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

namespace Server
{
    class Program
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
                    collection.AddSingleton<MagicOnionServiceDefinition>(magicOnionHost.Services.GetService<MagicOnionServiceDefinition>());
                })
                .UseKestrel()
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5432")
                .Build();

            // Run and wait both.
            await Task.WhenAll(webHost.RunAsync(), magicOnionHost.RunAsync());
        }
    }

    // WebAPI Startup configuration.
    public class Startup
    {
        // Inject MagicOnionServiceDefinition from DIl
        public void Configure(IApplicationBuilder app, MagicOnionServiceDefinition magicOnion)
        {
            // Optional:Add Summary to Swagger
            // var xmlName = "Sandbox.NetCoreServer.xml";
            // var xmlPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), xmlName);

            // HttpGateway requires two middlewares.
            // One is SwaggerView(MagicOnionSwaggerMiddleware)
            // One is Http1-JSON to gRPC-MagicOnion gateway(MagicOnionHttpGateway)

            app.UseMagicOnionSwagger(magicOnion.MethodHandlers, new SwaggerOptions("MagicOnion.Server", "Swagger Integration Test", "/")
            {
                // XmlDocumentPath = xmlPath
            });
            app.UseMagicOnionHttpGateway(magicOnion.MethodHandlers, new Channel("localhost:9001", ChannelCredentials.Insecure));
        }
    }

}
