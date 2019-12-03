using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WeatherForecast.WCF.Shared
{
    [DataContract]
    public class WeatherResult
    {
        [DataMember(Order = 1)]
        public IEnumerable<WeatherData> Forecasts { get; set; }
    }
}
