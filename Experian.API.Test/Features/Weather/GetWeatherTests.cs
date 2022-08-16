using Experian.API.Features.Weather;
using Experian.API.Interface;
using Experian.API.Model;
using Experian.API.Request;
using Moq;

namespace Experian.API.Test.Features.Weather
{
    [TestClass]
    public class GetWeatherTests
    {
        private GetWeather _getWeather;
        private Mock<IAppSettings<WeatherConfigRequest>> _mockAppSettings;
        private Mock<IAPIGetService<WeatherModel>> _mockService;
        private Mock<IURI<WeatherConfigRequest, WeatherRequest>> _mockUrl;

        [TestInitialize]
        public void SetUp()
        {
            _mockAppSettings = new Mock<IAppSettings<WeatherConfigRequest>>();
            _mockService = new Mock<IAPIGetService<WeatherModel>>();
            _mockUrl = new Mock<IURI<WeatherConfigRequest, WeatherRequest>>();

            _getWeather = new GetWeather
                (_mockAppSettings.Object, _mockService.Object, _mockUrl.Object); ;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_AppSettingsInstance() =>
        new GetWeather(null, _mockService.Object, _mockUrl.Object);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_ServiceInstance() =>
       new GetWeather(_mockAppSettings.Object, null, _mockUrl.Object);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_UrlInstance() =>
       new GetWeather(_mockAppSettings.Object, _mockService.Object, null);

        [TestMethod]
        public async Task Returns_Null_For_Null_AppSettingsValues()
        {
            var result = await _getWeather.Handler(new WeatherRequest());

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Returns_Null_For_Null_Url()
        {
            _mockAppSettings.Setup(s => s.GetAppSettings())
             .Returns(Task.FromResult(new WeatherConfigRequest()));

            var handler = _getWeather.Handler(new WeatherRequest());

            Assert.IsNull(handler.Result);
        }

        [TestMethod]
        public async Task Returns_Null_For_Null_Response_From_Service()
        {
            _mockAppSettings.Setup(s => s.GetAppSettings())
             .Returns(Task.FromResult(new WeatherConfigRequest()));

            _mockUrl.Setup(s => s.BuildUri(It.IsAny<WeatherConfigRequest>(),
                It.IsAny<WeatherRequest>()))
            .Returns("Test");

            var result = await _getWeather.Handler(new WeatherRequest());

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task Returns_WeatherModel_For_valid_Request()
        {
            _mockAppSettings.Setup(s => s.GetAppSettings())
             .Returns(Task.FromResult(new WeatherConfigRequest()));

            _mockUrl.Setup(s => s.BuildUri(It.IsAny<WeatherConfigRequest>(),
                It.IsAny<WeatherRequest>()))
            .Returns("Test");

            _mockService.Setup(s => s.GetData(It.IsAny<ServiceRequest>()))
          .Returns(Task.FromResult(new WeatherModel()));

            var result = await _getWeather.Handler(new WeatherRequest());

            Assert.IsNotNull(result);

            Assert.AreEqual(typeof(WeatherModel), result.GetType());
        }

    }
}
