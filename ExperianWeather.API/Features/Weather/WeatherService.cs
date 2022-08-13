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
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();

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
