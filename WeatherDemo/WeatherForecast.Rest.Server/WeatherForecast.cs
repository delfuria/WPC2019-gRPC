using System;

namespace WeatherForecast.Rest.Server
{
    public class WeatherForecast
    {
        public DateTime DateTime { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }
    }
}
