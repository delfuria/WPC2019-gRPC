﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HyperMathGrpcMagicShared
{
    [DataContract]
    public class WeatherReply
    {
        [DataMember]
        public List<WeatherData> WeatherData { get; set; }
    }
}
