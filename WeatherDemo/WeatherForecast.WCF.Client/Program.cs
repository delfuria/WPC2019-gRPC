using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ServiceModel;
using WeatherForecast.WCF.Shared;

namespace WeatherForecast.WCF.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press a key to start");
            Console.ReadKey();

            long times = 0;
            for (int i = 0; i < 10; i++)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                ClientProxy client =
                    new ClientProxy(new BasicHttpBinding(),
                                    new EndpointAddress("http://localhost:9001/WeatherService"));

                var response = client.GetWeather();

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
