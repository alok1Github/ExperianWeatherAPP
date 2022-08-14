using Experian.API.Interface;
using Experian.API.Model;
using Experian.API.Request;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;


namespace Experian.API.Features.City
{
    public class GetCitiesByCountryCode : IGet<CityRequest, CityModel>
    {
        private readonly IAppSettings<CityConfigRequest> appSettings;
        private readonly IAPIGetService<CityModel> service;
        private readonly IURI<CityConfigRequest, CityRequest> url;

        public GetCitiesByCountryCode(IAppSettings<CityConfigRequest> appSettings,
                          IAPIGetService<CityModel> service,
                          IURI<CityConfigRequest, CityRequest> uri)
        {
            Guard.ArgumentNotNull(appSettings, nameof(appSettings));
            Guard.ArgumentNotNull(service, nameof(service));
            Guard.ArgumentNotNull(uri, nameof(uri));

            this.appSettings = appSettings;
            this.service = service;
            this.url = uri;
        }

        public async Task<CityModel?> Handler(CityRequest request)
        {
            var settings = await appSettings.GetAppSettings();

            string url = this.url.BuildUri(settings, request);

            var serviceRequest = new ServiceRequest
            {
                Url = url,
                CustomHeader = settings.Key
            };

            return await service.GetData(serviceRequest);
        }
    }
}
