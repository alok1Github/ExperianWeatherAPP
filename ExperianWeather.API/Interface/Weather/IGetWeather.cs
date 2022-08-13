using Experian.API.Model;
using Experian.API.Request;

namespace Experian.API.Interface.Weather
{
    public interface IGetWeather
    {
        Task<WeatherModel?> Handler(WeatherRequest request);
    }
}
