using Experian.API.Interface;
using Experian.API.Model;
using Experian.API.Request;

namespace Experian.API.Features.Weather
{
    public class CityService : IAPIGetService<CityModel>
    {
        public async Task<CityModel?> GetData(ServiceRequest request)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(request.Url);
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Add("X-CSCAPI-KEY", request.CustomHeader);


                var response = await client.GetAsync(request.Url);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<List<CityResult>>();

                    return new CityModel { cities = result };
                }
            }

            return null;
        }
    }
}
