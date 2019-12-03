﻿using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherForecast.Grpc.Shared;

namespace WeatherForecast.Grpc.Protobuf.Client
{
    internal class Program
    {
        private static async Task Main()
        {
            Console.WriteLine("Press a key to start");
            Console.ReadKey();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            var http = GrpcChannel.ForAddress("http://localhost:5001");
            var client = http.CreateGrpcService<IWeatherForecasts>();

            var response = await client.GetWeatherAsync();

            stopWatch.Stop();
            foreach (var forecast in response.Forecasts)
            {
                Console.WriteLine($"{forecast.DateTime:s} | {forecast.Summary} | {forecast.TemperatureC} C");
            }

            Console.WriteLine($"Time Elapsed {stopWatch.ElapsedMilliseconds}");
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();

            Stopwatch stopWatch1 = new Stopwatch();
            stopWatch1.Start();
            var http1 = GrpcChannel.ForAddress("http://localhost:5001");
            var client1 = http.CreateGrpcService<IWeatherForecasts>();

            var response1 = await client1.GetWeatherAsync();

            stopWatch1.Stop();
            Console.WriteLine($"Time Elapsed {stopWatch1.ElapsedMilliseconds}");
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();

        }
    }
}
