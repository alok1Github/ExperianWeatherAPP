using Experian.API.Interface;
using Experian.API.Request;
namespace Experian.API.Features.Weather
{
    public class AppSettings : IAppSettings<WeatherConfigRequest>
    {
        public Task<WeatherConfigRequest> GetAppSettings() =>
            Task.Run(() => new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json")
                                .Build()
                                .GetSection(nameof(WeatherConfigRequest)).Get<WeatherConfigRequest>()
                    );
    }
}
