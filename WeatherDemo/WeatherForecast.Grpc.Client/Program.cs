using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using static WeatherForecast.WeatherForecasts;

namespace WeatherForecast.Grpc.Client
{
    internal class Program
    {
        private static async Task Main()
        {
            Console.WriteLine("Press a key to start");
            Console.ReadKey();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            using var channel = GrpcChannel.ForAddress("https://localhost:5005");

            var client = new WeatherForecastsClient(channel);
            
            var reply = await client.GetWeatherAsync(new Empty());
            stopWatch.Stop();

            foreach (var forecast in reply.WeatherData)
            {
                Console.WriteLine($"{forecast.DateTimeStamp.ToDateTime():s} | {forecast.Summary} | {forecast.TemperatureC} C");
            }

            Console.WriteLine($"Time Elapsed {stopWatch.ElapsedMilliseconds}");
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }
    }
}
