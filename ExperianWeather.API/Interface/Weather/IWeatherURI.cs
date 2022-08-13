using Experian.API.Request;

namespace Experian.API.Interface.Weather
{
    public interface IWeatherURI
    {
        string BuildUri(WeatherConfigRequest settings, WeatherRequest parms);
    }
}
