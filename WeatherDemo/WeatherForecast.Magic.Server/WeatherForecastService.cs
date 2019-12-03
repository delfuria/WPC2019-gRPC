using Grpc.Core;
using HyperMathGrpcMagicShared;
using MagicOnion;
using MagicOnion.Server;
using System;
using System.Linq;


// implement RPC service to Server Project.
// inehrit ServiceBase<interface>, interface
public class WeatherForecastServeice : ServiceBase<IWeatherForecast>, IWeatherForecast
{
    private static readonly string[] Summaries =
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    public async UnaryResult<WeatherReply> GetWeather()
    {
        var rng = new Random();
        var now = DateTime.UtcNow;

        var forecasts = Enumerable.Range(1, 100).Select(index => new WeatherData
        {
            DateTimeStamp = DateTime.Now.AddDays(index),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)]
        })
        .ToList();

        //await Task.Delay(2000); // Gotta look busy

        return new WeatherReply
        {
            WeatherData = forecasts
        };
    }
    // You can use async syntax directly.
    //public async UnaryResult<double> Sum(double op1, double op2)
    //{
    //    Logger.Debug($"Received:{op1}, {op2}");

    //    return op1 + op2;
    //}
}