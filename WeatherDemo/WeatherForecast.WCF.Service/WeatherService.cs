using System;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.WCF.Shared;

namespace WeatherForecast.WCF.Service
{
    public class WeatherService : IWeatherForecasts
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public  WeatherResult GetWeather()
        {
            var rng = new Random();
            var now = DateTime.UtcNow;

            var forecasts = Enumerable.Range(1, 100).Select(index => new WeatherData
            {
                DateTime = now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            //await Task.Delay(2000); // Gotta look busy

            return new WeatherResult { Forecasts = forecasts };
        }
    }
}
