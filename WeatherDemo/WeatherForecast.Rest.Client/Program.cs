using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherForecast.Rest.Client
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

                using var httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:5001") };

                using var response = await httpClient.GetAsync("weatherforecast");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStreamAsync();

                    var forecasts = await JsonSerializer.DeserializeAsync<WeatherForecasts>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    stopWatch.Stop();

                    if (i == 0)
                        foreach (var forecast in forecasts.Forecasts)
                        {
                            Console.WriteLine($"{forecast.DateTime:s} | {forecast.Summary} | {forecast.TemperatureC} C");
                        }
                    else
                        times += stopWatch.ElapsedMilliseconds;
                }

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
