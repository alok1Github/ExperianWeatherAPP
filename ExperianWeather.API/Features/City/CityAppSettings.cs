using Experian.API.Interface;
using Experian.API.Request;

namespace Experian.API.Features.City
{
    public class CityAppSettings : IAppSettings<CityConfigRequest>
    {
        public Task<CityConfigRequest> GetAppSettings() =>
            Task.Run(() => new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json")
                                .Build()
                                .GetSection(nameof(CityConfigRequest)).Get<CityConfigRequest>()
                    );
    }
}
