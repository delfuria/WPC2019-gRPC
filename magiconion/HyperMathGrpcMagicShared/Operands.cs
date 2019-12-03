using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HyperMathGrpcMagicShared
{
    [DataContract]
    public class Operands
    {
        [DataMember(Name = "Value1")]
        public double Op1 { get; set; }
        [DataMember(Name = "Value2")]
        public double Op2 { get; set; }
    }
}
