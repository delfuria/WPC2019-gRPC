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

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //Step 1: Crea una istanza del WCF proxy.
            ClientProxy client =
                new ClientProxy(new BasicHttpBinding(),
                                new EndpointAddress("http://localhost:9001/WeatherService"));

            var response = client.GetWeather();

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
            ClientProxy client1 =
                new ClientProxy(new BasicHttpBinding(),
                                new EndpointAddress("http://localhost:9001/WeatherService"));

            var response1 = client1.GetWeather();

            stopWatch1.Stop();
            Console.WriteLine($"Time Elapsed {stopWatch1.ElapsedMilliseconds}");
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();


        }
    }
}
