using Experian.API.Interface;
using Experian.API.Model;

namespace Experian.API.Features.Weather
{
    public class WeatherService : IAPIGetService<WeatherModel>
    {
        public async Task<WeatherModel?> GetData(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("tdtdtd");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<WeatherModel>();
                }
            }

            return null;
        }
    }
}
