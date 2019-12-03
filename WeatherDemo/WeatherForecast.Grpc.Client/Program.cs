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

            Stopwatch stopWatch1 = new Stopwatch();
            stopWatch1.Start();

            using var channel1 = GrpcChannel.ForAddress("https://localhost:5005");

            var client1 = new WeatherForecastsClient(channel1);

            var reply1 = await client.GetWeatherAsync(new Empty());
            stopWatch1.Stop();
            Console.WriteLine($"Time Elapsed {stopWatch1.ElapsedMilliseconds}");
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();

        }
    }
}
