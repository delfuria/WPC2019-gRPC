using Grpc.Core;
using HyperMathGrpcMagicShared;
using MagicOnion.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Magic.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the gRPC client, Press Enter to continue");
            Console.ReadLine();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var channel = new Channel("localhost", 5001, ChannelCredentials.Insecure);
            var client = MagicOnionClient.Create<IWeatherForecast>(channel);
            var reply = await client.GetWeather();
            stopWatch.Stop();


            foreach (var forecast in reply.WeatherData)
            {
                Console.WriteLine($"{forecast.DateTimeStamp.ToLongTimeString():s} | {forecast.Summary} | {forecast.TemperatureC} C");
            }

            Console.WriteLine($"Time Elapsed {stopWatch.ElapsedMilliseconds}");
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }
    }
}
