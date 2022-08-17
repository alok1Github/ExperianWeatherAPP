using Experian.API.Interface;
using Experian.API.Model;
using Experian.API.Request;

namespace Experian.API.Features.Weather
{
    public class WeatherService : IAPIGetService<WeatherModel>
    {
        public async Task<WeatherModel?> GetData(ServiceRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request?.Uri)) return null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(request.Uri);
                client.DefaultRequestHeaders.Accept.Clear();

                var response = await client.GetAsync(request.Uri);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<WeatherModel>();
                }
            }

            return null;
        }

    }
}
