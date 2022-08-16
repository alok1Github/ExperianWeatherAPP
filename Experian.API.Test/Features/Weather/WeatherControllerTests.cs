using Experian.API.Features.Weather;
using Experian.API.Interface;
using Experian.API.Model;
using Experian.API.Request;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Experian.API.Test.Features.Weather
{

    [TestClass]
    public class WeatherControllerTests
    {
        private WeatherController _controller;
        private Mock<IGet<WeatherRequest, WeatherModel>> _mockGet;

        [TestInitialize]
        public void SetUp()
        {
            _mockGet = new Mock<IGet<WeatherRequest, WeatherModel>>();

            _controller = new WeatherController(_mockGet.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_Dependencies() =>
        new WeatherController(null);

        [TestMethod]
        public async Task Returns_BadRequestResult_For_Null_Request()
        {
            var result = await _controller.Get(null);

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(BadRequestResult), result.GetType());
        }

        [TestMethod]
        public async Task Returns_NotFoundResult_For_NullResponse_FromHandler()
        {
            var result = await _controller.Get(new WeatherRequest());

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(NotFoundResult), result.GetType());
        }

        [TestMethod]
        public async Task Returns_NotFoundResult_For_NullResponse_FromHandlerssss()
        {
            _mockGet.Setup(s => s.Handler(It.IsAny<WeatherRequest>()))
               .Returns(Task.FromResult(new WeatherModel()));

            var result = await _controller.Get(new WeatherRequest());


            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
        }


    }
}
