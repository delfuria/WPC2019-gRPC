using Grpc.Net.Client;
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

            long times = 0;
            for (int i = 0; i < 10; i++)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                GrpcClientFactory.AllowUnencryptedHttp2 = true;
                var http = GrpcChannel.ForAddress("http://localhost:5001");
                var client = http.CreateGrpcService<IWeatherForecasts>();
                var response = await client.GetWeatherAsync();

                stopWatch.Stop();

                if (i == 0)
                    foreach (var forecast in response.Forecasts)
                    {
                        Console.WriteLine($"{forecast.DateTime:s} | {forecast.Summary} | {forecast.TemperatureC} C");
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
    }
}
