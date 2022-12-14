using Experian.API.Interface;
using Experian.API.Model;
using Experian.API.Request;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;

namespace Experian.API.Features.Weather
{
    public class GetWeather : IGet<WeatherRequest, WeatherModel>
    {
        private readonly IAppSettings<WeatherConfigRequest> appSettings;
        private readonly IAPIGetService<WeatherModel> service;
        private readonly IURI<WeatherConfigRequest, WeatherRequest> uri;

        public GetWeather(IAppSettings<WeatherConfigRequest> appSettings,
                          IAPIGetService<WeatherModel> service,
                          IURI<WeatherConfigRequest, WeatherRequest> uri)
        {
            Guard.ArgumentNotNull(appSettings, nameof(appSettings));
            Guard.ArgumentNotNull(service, nameof(service));
            Guard.ArgumentNotNull(uri, nameof(uri));

            this.appSettings = appSettings;
            this.service = service;
            this.uri = uri;
        }

        public async Task<WeatherModel?> Handler(WeatherRequest request)
        {
            var settings = await appSettings.GetAppSettings();

            string uri = this.uri.BuildUri(settings, request);

            var result = await service.GetData(new ServiceRequest
            {
                Uri = uri
            });

            return result;
        }
    }
}
