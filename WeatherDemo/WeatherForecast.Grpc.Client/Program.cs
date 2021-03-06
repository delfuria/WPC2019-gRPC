﻿using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using static WeatherForecast.WeatherForecasts;

namespace WeatherForecast.Grpc.Client
{
    internal class Program
    {
        private static async Task Main()
        {
            Console.WriteLine("Press a key to start");
            Console.ReadKey();

            long times = 0;
            for (int i = 0; i < 10; i++)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                //// Configure a channel to use gRPC
                var channel = GrpcChannel.ForAddress("https://localhost:5005");

                //// Configure a channel to use gRPC-Web
                //var handler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
                //var channel = GrpcChannel.ForAddress("https://localhost:5005", new GrpcChannelOptions
                //{
                //    HttpClient = new HttpClient(handler)
                //});


                var client = new WeatherForecastsClient(channel);
                var reply = await client.GetWeatherAsync(new Empty());

                stopWatch.Stop();

                if (i == 0)
                    foreach (var forecast in reply.WeatherData)
                    {
                        Console.WriteLine($"{forecast.DateTimeStamp.ToDateTime():s} | {forecast.Summary} | {forecast.TemperatureC} C");
                    }
                else
                    times += stopWatch.ElapsedMilliseconds;
                Console.WriteLine($"Time Elapsed {stopWatch.ElapsedMilliseconds}");
                Console.WriteLine("Press a key to exit");
                Console.ReadKey();
            }
            Console.WriteLine($"Average time:{times / 9}");
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }

        //private static async Task Main()
        //{
        //    Console.WriteLine("Press a key to start");
        //    Console.ReadKey();

        //    long times = 0;
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Stopwatch stopWatch = new Stopwatch();
        //        stopWatch.Start();

        //        // Configure a channel to use gRPC-Web
        //        var handler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
        //        var channel = GrpcChannel.ForAddress("https://localhost:5005", new GrpcChannelOptions
        //        {
        //            HttpClient = new HttpClient(handler)
        //        });


        //        var client = new WeatherForecastsClient(channel);
        //        var reply = await client.GetWeatherAsync(new Empty());

        //        stopWatch.Stop();

        //        if (i == 0)
        //            foreach (var forecast in reply.WeatherData)
        //            {
        //                Console.WriteLine($"{forecast.DateTimeStamp.ToDateTime():s} | {forecast.Summary} | {forecast.TemperatureC} C");
        //            }
        //        else
        //            times += stopWatch.ElapsedMilliseconds;
        //        Console.WriteLine($"Time Elapsed {stopWatch.ElapsedMilliseconds}");
        //        Console.WriteLine("Press a key to exit");
        //        Console.ReadKey();
        //    }
        //    Console.WriteLine($"Average time:{times / 9}");
        //    Console.WriteLine("Press a key to exit");
        //    Console.ReadKey();
        //}

    }
}
