using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HyperMathGrpcMagicShared
{
    [MessagePackObject]
    public class WeatherReply
    {
        [Key(0)]
        public List<WeatherData> WeatherData { get; set; }
    }
}
