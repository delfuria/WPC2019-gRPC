using System.ServiceModel;
using System.Threading.Tasks;

namespace WeatherForecast.WCF.Shared
{
    [ServiceContract(Name = "WeatherForecasting.WCF")]
    public interface IWeatherForecasts
    {
        [OperationContract]
        WeatherResult GetWeather();
    }
}
