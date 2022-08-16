using Experian.API.Filters;
using Experian.API.Model;
using Experian.API.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Moq;

namespace Experian.API.Test.Filters
{
    [TestClass]
    public class TempratureFilterTests
    {
        private TempratureFilter _filter;
        private List<IFilterMetadata> _metaData;
        private ActionExecutingContext _executingContext;
        private ActionExecutedContext _executedContext;

        [TestInitialize]
        public void SetUp()
        {
            _filter = new TempratureFilter();
            _metaData = new List<IFilterMetadata>();

            ActionContext();

            _executingContext = new ActionExecutingContext(ActionContext(), _metaData,
                                                 new Dictionary<string, object>(),
                                                 new Mock<Controller>().Object);

            _executedContext = new ActionExecutedContext(ActionContext(),
                                                    new List<IFilterMetadata>(),
                                                    new Mock<Controller>().Object);
        }

        [TestMethod]
        public void Temprature_Set_to_Fahrenheit_For_FahrenheitRequest()
        {
            // Arrange
            var request = new WeatherRequest { TempratureUnit = TempratureEnum.Fahrenheit };

            var result = new WeatherModel
            {
                CurrentDetails = new TempratureModel
                {
                    TempratureInCelsius = 10,
                    TempFahrenheit = 50,
                    Temprature = 100
                }
            };

            BuildContext(request, result);

            Assert.AreEqual(result.CurrentDetails.Temprature, 100);

            // Act
            _filter.OnActionExecuting(_executingContext);
            _filter.OnActionExecuted(_executedContext);

            // Assert
            Assert.AreEqual(result.CurrentDetails.Temprature, 50);

        }

        [TestMethod]
        public void Temprature_Set_to_Celsius_For_CelsiusRequest()
        {
            // Arrange
            var request = new WeatherRequest { TempratureUnit = TempratureEnum.Celsius };

            var result = new WeatherModel
            {
                CurrentDetails = new TempratureModel
                {
                    TempratureInCelsius = 10,
                    TempFahrenheit = 50,
                    Temprature = 100
                }
            };

            BuildContext(request, result);

            Assert.AreEqual(result.CurrentDetails.Temprature, 100);

            // Act
            _filter.OnActionExecuting(_executingContext);
            _filter.OnActionExecuted(_executedContext);

            // Assert
            Assert.AreEqual(result.CurrentDetails.Temprature, 10);

        }

        private void BuildContext(WeatherRequest request, WeatherModel result)
        {
            _executingContext.Result = new ObjectResult(result);
            _executedContext.Result = new ObjectResult(result);

            _executingContext.ActionArguments.Add("request", request);
        }

        private static ActionContext ActionContext() =>
             new ActionContext(
                     httpContext: new DefaultHttpContext(),
                     routeData: new RouteData(),
                     actionDescriptor: new ActionDescriptor(),
                     modelState: new ModelStateDictionary());
    }
}
