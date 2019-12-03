using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HyperMathProtobufNetGrpcLibrary
{
    [ServiceContract(Name = "HyperCalculator")]
    public interface IHyperMath
    {
        ValueTask<MathReply> SumAsync(MathRequest request);
    }

    [DataContract]
    public class MathRequest
    {
        [DataMember(Order = 1)]
        public double Op1 { get; set; }

        [DataMember(Order = 2)]
        public double Op2 { get; set; }
    }

    [DataContract]
    public class MathReply
    {
        [DataMember(Order = 1)]
        public double Resp { get; set; }
    }
}
