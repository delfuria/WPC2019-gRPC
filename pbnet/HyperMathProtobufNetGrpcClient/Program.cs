using Grpc.Net.Client;
using HyperMathProtobufNetGrpcLibrary;
using ProtoBuf.Grpc.Client;
using System;
using System.Threading.Tasks;
using WeatherForecast.Grpc.Shared;

namespace HyperMathProtobufNetGrpcClient
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the gRPC client, Press Enter to continue");
            Console.ReadLine();

            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            var http = GrpcChannel.ForAddress("http://localhost:5001");
            //var calculator = http.CreateGrpcService<IHyperMath>();
            //var result = await calculator.SumAsync(new MathRequest { Op1 = 10, Op2 = 20 });

            //Console.WriteLine(result.Resp); // 30
            //Console.ReadLine();

            var client = http.CreateGrpcService<IWeatherForecasts>();

            var response = await client.GetWeatherAsync();

            foreach (var forecast in response.Forecasts)
            {
                Console.WriteLine($"{forecast.DateTime:s} | {forecast.Summary} | {forecast.TemperatureC} C");
            }

            Console.ReadLine();

        }
    }
}
