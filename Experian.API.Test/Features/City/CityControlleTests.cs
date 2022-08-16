using Experian.API.Features.City;
using Experian.API.Interface;
using Experian.API.Model;
using Experian.API.Request;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Experian.API.Test.Features.Weather
{

    [TestClass]
    public class CityControllerTests
    {
        private CityController _controller;
        private Mock<IGet<CityRequest, CityModel>> _mockGet;

        [TestInitialize]
        public void SetUp()
        {
            _mockGet = new Mock<IGet<CityRequest, CityModel>>();
            _controller = new CityController(_mockGet.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_Dependencies() =>
        new CityController(null);

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
            var result = await _controller.Get(new CityRequest());

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(NotFoundResult), result.GetType());
        }

        [TestMethod]
        public async Task Returns_NotFoundResult_For_NullResponse_FromHandlerssss()
        {
            _mockGet.Setup(s => s.Handler(It.IsAny<CityRequest>()))
               .Returns(Task.FromResult(new CityModel()));

            var result = await _controller.Get(new CityRequest());

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
        }
    }
}
