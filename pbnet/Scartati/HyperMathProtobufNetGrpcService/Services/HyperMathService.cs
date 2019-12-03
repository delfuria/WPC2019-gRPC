using HyperMathProtobufNetGrpcLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HyperMathProtobufNetGrpcService
{
    public class MathService : IHyperMath
    {

        ValueTask<MathReply> IHyperMath.SumAsync(MathRequest request)
        {
            var result = new MathReply { Resp = request.Op1 + request.Op2 };
            return new ValueTask<MathReply>(result);
        }
    }
}


