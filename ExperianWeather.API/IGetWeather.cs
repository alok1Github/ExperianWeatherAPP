using Experian.API.Model;
using Experian.API.Request;

namespace Experian.API
{
    public interface IGetWeather
    {
        Task<WeatherModel> Handler(WeatherRequest request);
    }
}
