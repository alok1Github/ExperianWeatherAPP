using Microsoft.AspNetCore.Mvc;

namespace Experian.API.Features.Weather
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        // private readonly IGetWeather getWeather;

        //public CityController(IGetWeather getWeather)
        //{
        //    Guard.ArgumentNotNull(getWeather, nameof(getWeather));

        //    this.getWeather = getWeather;
        //}


        //[HttpPost(Name = "GetCityByCountryCode")]
        //public async Task<IActionResult> Get(WeatherRequest request)
        //{
        //    if (request == null) BadRequest();

        //    var result = await this.getWeather.Handler(request);

        //    return result != null ? Ok(result) : NotFound();
        //}
    }
}
