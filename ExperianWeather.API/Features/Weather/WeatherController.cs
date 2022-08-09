using ExperianWeather.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace ExperianWeather.API.Features.Weather
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        /// <summary>
        /// Get WeatherForecast 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetWeatherForecast()
        {

            var result = await
                 GetProductAsync("http://api.weatherapi.com/v1/current.json?key=e0796082219144bca7590818220908&q=Edinburgh&aqi=yes");



            return Ok(result);
        }

        static async Task<WeatherModel> GetProductAsync(string path)
        {
            var weather = new WeatherModel();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    weather = await response.Content.ReadFromJsonAsync<WeatherModel>();         
                }
            }

            return weather;
        }
    }
}
