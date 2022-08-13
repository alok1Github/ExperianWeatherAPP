using Experian.API.Model;
using Experian.API.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Experian.API.ExceptionHandlers
{
    public class TempratureFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var request = context.ModelState.Values.ToArray()[3].AttemptedValue;
            var result = ((WeatherModel?)((ObjectResult?)context.Result).Value);

            Enum.TryParse(request, out TempratureEnum temprature);

            if (temprature == TempratureEnum.Fahrenheit)
            {
                result.CurrentDetails.Temprature = result.CurrentDetails.TempFahrenheit;

            }
            else
            {
                result.CurrentDetails.Temprature = result.CurrentDetails.TempratureInCelsius;

            }
        }
    }
}
