using Experian.API.Interface;
using Experian.API.Request;
using Flurl;

namespace Experian.API.Features.Weather
{
    public class WeatherURIBuilder : IURI<WeatherConfigRequest, WeatherRequest>
    {
        public string BuildUri(WeatherConfigRequest settings, WeatherRequest parms)
        {
            if (settings == null || parms == null) return null;

            return settings.BaseUrl
                        .SetQueryParam("key", settings.Key)
                        .SetQueryParam("q", parms.City)
                        .SetQueryParam("aqi", parms.AirQuality);
        }
    }
}
