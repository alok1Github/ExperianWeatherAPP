using Experian.API.Filters;
using Experian.API.Interface;
using Experian.API.Model;
using Experian.API.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;

namespace Experian.API.Features.Weather
{
    [Route("api/[controller]")]
    [ApiController]
    [TempratureFilter]
    public class WeatherController : ControllerBase
    {
        private readonly IGet<WeatherRequest, WeatherModel> get;

        public WeatherController(IGet<WeatherRequest, WeatherModel> get)
        {
            Guard.ArgumentNotNull(get, nameof(get));

            this.get = get;
        }

        [HttpGet(Name = "GetWeatherReport")]
        public async Task<IActionResult> Get([FromQuery] WeatherRequest request)
        {
            if (request == null) return BadRequest();

            var result = await this.get.Handler(request);

            return result != null ? Ok(result) : NotFound();
        }
    }
}
