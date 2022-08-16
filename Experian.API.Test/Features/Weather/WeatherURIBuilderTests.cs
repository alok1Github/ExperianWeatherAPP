using Experian.API.Features.Weather;
using Experian.API.Request;

namespace Experian.API.Test.Features.Weather
{
    [TestClass]
    public class WeatherURIBuilderTests
    {
        private WeatherURIBuilder _uriBuilder;

        [TestInitialize]
        public void SetUp()
        {
            _uriBuilder = new WeatherURIBuilder();
        }

        [TestMethod]
        public void Returns_Null_For_null_ConfigSettingsInstance()
        {
            var result = _uriBuilder.BuildUri(null, new WeatherRequest());

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Returns_Null_For_null_RequesObject()
        {
            var result = _uriBuilder.BuildUri(new WeatherConfigRequest(), null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Throws_Null_Exception_For_Null_Dependencies()
        {
            var settings = new WeatherConfigRequest();
            settings.BaseUrl = "http://api.weatherapi.com/v1/current.json?";
            settings.Key = "e0796082219144bca7590818220908";

            var param = new WeatherRequest();
            param.City = "Sagar";

            var expectedUri = "http://api.weatherapi.com/v1/current.json?key=e0796082219144bca7590818220908&q=Sagar&aqi=False";

            var result = _uriBuilder.BuildUri(settings, param);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, expectedUri);
        }
    }
}
