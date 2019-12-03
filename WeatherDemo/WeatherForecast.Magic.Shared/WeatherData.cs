using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HyperMathGrpcMagicShared
{
    [MessagePackObject]
    public class WeatherData
    {
        [Key(0)]
        public DateTime DateTimeStamp { get; set; }
        [Key(1)]
        public int TemperatureC { get; set; }
        [Key(2)]
        public string Summary { get; set; }
    }
}
