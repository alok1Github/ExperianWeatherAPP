using Experian.API.Model;
using Experian.API.Request;

namespace Experian.API.Features.Weather
{
    public class GetWeather : IGetWeather
    {
        public async Task<WeatherModel?> Handler(WeatherRequest request)  
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var section = config.GetSection(nameof(WeatherConfigRequest));
            var weatherClientConfig = section.Get<WeatherConfigRequest>();

            using (var client = new HttpClient())
            {
                var url = $"{weatherClientConfig.Url}key={weatherClientConfig.Key}&q={request.City}&{request.AirQuality}";
                var response = await client.GetAsync(url);            

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<WeatherModel>();                     
                }
            }

            return null;
        }
    }
}
                                                                                                            