using Experian.API.Interface;
using Experian.API.Interface.Weather;
using Experian.API.Model;
using Experian.API.Request;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;


namespace Experian.API.Features.Weather
{
    public class GetWeather : IGetWeather
    {
        private readonly IAppSettings<WeatherConfigRequest> appSettings;
        private readonly IAPIGetService<WeatherModel> service;
        private readonly IWeatherURI url;

        public GetWeather(IAppSettings<WeatherConfigRequest> appSettings,
                          IAPIGetService<WeatherModel> service, IWeatherURI uri)
        {
            Guard.ArgumentNotNull(appSettings, nameof(appSettings));
            Guard.ArgumentNotNull(service, nameof(service));
            Guard.ArgumentNotNull(uri, nameof(uri));

            this.appSettings = appSettings;
            this.service = service;
            this.url = uri;
        }

        public async Task<WeatherModel?> Handler(WeatherRequest request)
        {
            var settings = await appSettings.GetAppSettings();

            string url = this.url.BuildUri(settings, request);

            return await service.GetData(url);
        }
    }
}
