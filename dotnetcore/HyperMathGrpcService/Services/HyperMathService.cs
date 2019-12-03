using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using HyperMath.Grpc;
using Microsoft.Extensions.Logging;

namespace HyperMathGrpcService
{
    public class HyperMathService : HyperMath.Grpc.MathService.MathServiceBase
    {
        private readonly ILogger<HyperMathService> _logger;
        public HyperMathService(ILogger<HyperMathService> logger)
        {
            _logger = logger;
        }

        public override Task<MathReply> Sum(MathRequest request, ServerCallContext context)
        {
            return Task.FromResult(new MathReply
            {
                Resp = request.Op1 + request.Op2
            });
        }

        public async override Task GetAllCalc(MathRequest request, IServerStreamWriter<MathReply> responseStream, ServerCallContext context)
        {
            await responseStream.WriteAsync(new MathReply { Resp = request.Op1 + request.Op2 });
            await Task.Delay(500);
            await responseStream.WriteAsync(new MathReply { Resp = request.Op1 - request.Op2 });
            await Task.Delay(1500);
            await responseStream.WriteAsync(new MathReply { Resp = request.Op1 * request.Op2 });
            await Task.Delay(1000);
            await responseStream.WriteAsync(new MathReply { Resp = request.Op1 / request.Op2 });
        }
    }
}

