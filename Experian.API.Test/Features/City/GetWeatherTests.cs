using Experian.API.Features.City;
using Experian.API.Interface;
using Experian.API.Model;
using Experian.API.Request;
using Moq;

namespace Experian.API.Test.Features.Weather
{
    [TestClass]
    public class GetCitiesByCountryCodeTests
    {
        private GetCitiesByCountryCode _GetCitiesByCountryCode;
        private Mock<IAppSettings<CityConfigRequest>> _mockAppSettings;
        private Mock<IAPIGetService<CityModel>> _mockService;
        private Mock<IURI<CityConfigRequest, CityRequest>> _mockUrl;

        [TestInitialize]
        public void SetUp()
        {
            _mockAppSettings = new Mock<IAppSettings<CityConfigRequest>>();
            _mockService = new Mock<IAPIGetService<CityModel>>();
            _mockUrl = new Mock<IURI<CityConfigRequest, CityRequest>>();

            _GetCitiesByCountryCode = new GetCitiesByCountryCode
                (_mockAppSettings.Object, _mockService.Object, _mockUrl.Object); ;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_AppSettingsInstance() =>
        new GetCitiesByCountryCode(null, _mockService.Object, _mockUrl.Object);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_ServiceInstance() =>
       new GetCitiesByCountryCode(_mockAppSettings.Object, null, _mockUrl.Object);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_UrlInstance() =>
       new GetCitiesByCountryCode(_mockAppSettings.Object, _mockService.Object, null);

        [TestMethod]
        public async Task Returns_Null_For_Null_AppSettingsValues()
        {
            var result = await _GetCitiesByCountryCode.Handler(new CityRequest());

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Returns_Null_For_Null_Url()
        {
            _mockAppSettings.Setup(s => s.GetAppSettings())
             .Returns(Task.FromResult(new CityConfigRequest()));

            var handler = _GetCitiesByCountryCode.Handler(new CityRequest());

            Assert.IsNull(handler.Result);
        }

        [TestMethod]
        public async Task Returns_Null_For_Null_Response_From_Service()
        {
            _mockAppSettings.Setup(s => s.GetAppSettings())
             .Returns(Task.FromResult(new CityConfigRequest()));

            _mockUrl.Setup(s => s.BuildUri(It.IsAny<CityConfigRequest>(),
                It.IsAny<CityRequest>()))
            .Returns("Test");

            var result = await _GetCitiesByCountryCode.Handler(new CityRequest());

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task Returns_CityModel_For_valid_Request()
        {
            _mockAppSettings.Setup(s => s.GetAppSettings())
             .Returns(Task.FromResult(new CityConfigRequest()));

            _mockUrl.Setup(s => s.BuildUri(It.IsAny<CityConfigRequest>(),
                It.IsAny<CityRequest>()))
            .Returns("Test");

            _mockService.Setup(s => s.GetData(It.IsAny<ServiceRequest>()))
          .Returns(Task.FromResult(new CityModel()));

            var result = await _GetCitiesByCountryCode.Handler(new CityRequest());

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(CityModel), result.GetType());
        }

    }
}
