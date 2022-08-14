using Experian.API.Interface;
using Experian.API.Request;
using Flurl;

namespace Experian.API.Features.City
{

    public class CityURIBuilder : IURI<CityConfigRequest, CityRequest>
    {
        public string BuildUri(CityConfigRequest settings, CityRequest parms) =>
             Url.Combine(settings.BaseUrl, parms.CountryCode, "/cities");
    }
}
