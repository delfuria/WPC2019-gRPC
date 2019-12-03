using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.WCF.Shared
{
    public class ClientProxy
           : ClientBase<IWeatherForecasts>,
             IWeatherForecasts
    {
        public ClientProxy(Binding binding,
            EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public WeatherResult GetWeather()
        {
            return Channel.GetWeather();
        }
    }
}
