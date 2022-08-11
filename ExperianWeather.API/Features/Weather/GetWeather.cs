using Experian.API.Model;
using Experian.API.Request;

namespace Experian.API.Features.Weather
{
    public class GetWeather : IGetWeather
    {
        public async Task<WeatherModel> Handler(WeatherRequest request)
        {
            var weather = new WeatherModel();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://api.weatherapi.com/v1/current.json?key=e0796082219144bca7590818220908&q=Edinburgh&aqi=yes");

                // HttpResponseMessage response = await client.GetAsync("http://api.weatherapi.com/v1/current.json?key=e0796082219144bca7590818220908&q=Edinburgh&aqi=yes");
                if (response.IsSuccessStatusCode)
                {
                    weather = await response.Content.ReadFromJsonAsync<WeatherModel>();
                }
            }

            return weather;
        }
    }
}
