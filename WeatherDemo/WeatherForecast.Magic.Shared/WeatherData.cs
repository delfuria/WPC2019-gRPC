using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HyperMathGrpcMagicShared
{
    [DataContract]
    public class WeatherData
    {
        [DataMember]
        public DateTime DateTimeStamp { get; set; }
        [DataMember]
        public int TemperatureC { get; set; }
        [DataMember]
        public string Summary { get; set; }
    }
}
