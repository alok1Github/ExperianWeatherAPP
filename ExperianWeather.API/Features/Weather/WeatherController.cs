using Experian.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using Experian.API.Request;

namespace Experian.API.Features.Weather
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IGetWeather getWeather;

        public WeatherController(IGetWeather getWeather)
        {
            Guard.ArgumentNotNull(getWeather, nameof(getWeather));

            this.getWeather = getWeather;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherForecast([FromQuery] WeatherRequest request )
        {
            if (request == null) BadRequest();          

            var result = await this.getWeather.Handler(request);

            return result != null ? Ok(result) : NotFound();            
        }
    }
}
