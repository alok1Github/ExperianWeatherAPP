using Experian.API.Interface;
using Experian.API.Model;
using Experian.API.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;

namespace Experian.API.Features.City
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IGet<CityRequest, CityModel> get;

        public CityController(IGet<CityRequest, CityModel> get)
        {
            Guard.ArgumentNotNull(get, nameof(get));

            this.get = get;
        }


        [HttpGet(Name = "GetCitiesByCountryCode")]
        public async Task<IActionResult> Get([FromQuery] CityRequest request)
        {
            if (request == null) BadRequest();

            var result = await this.get.Handler(request);

            return result != null ? Ok(result) : NotFound();
        }
    }
}
