using Experian.API.Interface.Weather;
using Experian.API.Request;
using Flurl;

namespace Experian.API.Features.Weather
{

    public class WeatherURIBuilder : IWeatherURI
    {
        public string BuildUri(WeatherConfigRequest settings, WeatherRequest parms) =>
                settings.BaseUrl
                        .SetQueryParam("key", settings.Key)
                        .SetQueryParam("q", parms.City)
                        .SetQueryParam("aqi", parms.AirQuality);
    }
}
