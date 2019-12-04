using Grpc.Core;
using MagicOnion;
using MagicOnion.HttpGateway.Swagger;
using MagicOnion.Server;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperMathGrpcMagicServiceHost
{
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
            app.UseMagicOnionHttpGateway(magicOnion.MethodHandlers, new Channel("localhost:5001", ChannelCredentials.Insecure));
        }
    }
}
