using Experian.API.Features.City;
using Experian.API.Request;

namespace Experian.API.Test.Features.Weather
{
    [TestClass]
    public class CityURIBuilderTests
    {
        private CityURIBuilder _uriBuilder;

        [TestInitialize]
        public void SetUp()
        {
            _uriBuilder = new CityURIBuilder();
        }

        [TestMethod]
        public void Returns_Null_For_null_ConfigSettingsInstance()
        {
            var result = _uriBuilder.BuildUri(null, new CityRequest());

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Returns_Null_For_null_RequesObject()
        {
            var result = _uriBuilder.BuildUri(new CityConfigRequest(), null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Throws_Null_Exception_For_Null_Dependencies()
        {
            var settings = new CityConfigRequest();
            settings.BaseUrl = "https://api.countrystatecity.in/v1/countries/";

            var param = new CityRequest();
            param.CountryCode = "IN";

            var expectedUri = "https://api.countrystatecity.in/v1/countries/IN/cities";

            var result = _uriBuilder.BuildUri(settings, param);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, expectedUri);
        }

    }
}
