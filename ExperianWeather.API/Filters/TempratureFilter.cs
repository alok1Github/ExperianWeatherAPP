using Experian.API.Model;
using Experian.API.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Experian.API.Filters
{
    public class TempratureFilter : ActionFilterAttribute
    {
        private TempratureEnum temprature;

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            temprature = (actionContext.ActionArguments.Single().Value as WeatherRequest).TempratureUnit;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var result = ((WeatherModel?)((ObjectResult?)context.Result).Value);

            result.CurrentDetails.Temprature = temprature == TempratureEnum.Fahrenheit
                                            ? result.CurrentDetails.TempFahrenheit
                                            : result.CurrentDetails.TempratureInCelsius;
        }
    }
}
