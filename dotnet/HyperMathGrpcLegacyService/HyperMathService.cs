using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using  HyperMath.Grpc;

namespace HyperMathGrpcLegacyService
{
    public class HyperMathService : HyperMath.Grpc.MathService.MathServiceBase
    {
        // Server side handler of the  RPC Call
        public override Task<MathReply> Sum(MathRequest request, ServerCallContext context)
        {
            double result = request.Op1 + request.Op2;
            return Task.FromResult(new MathReply() { Resp = result });
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
