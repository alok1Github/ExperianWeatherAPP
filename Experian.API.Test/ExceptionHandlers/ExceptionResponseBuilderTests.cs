using Experian.API.ExceptionHandlers;
using Microsoft.AspNetCore.Http;

namespace Experian.API.Test.ExceptionHandlers
{
    [TestClass]
    public class ExceptionResponseBuilderTests
    {
        [TestMethod]
        public void Returns_Exception_Message_If__Available_In_Exception()
        {
            var model = ExceptionResponseBuilder.createRespone(new Exception(), new DefaultHttpContext());

            Assert.IsNotNull(model);
            Assert.AreEqual(model.ErrorMessage.Trim(), "Exception of type 'System.Exception' was thrown.".Trim());
        }

        [TestMethod]
        public void Returns_Default_Message_If_No_Message_In_Exception()
        {
            var model = ExceptionResponseBuilder.createRespone(null, new DefaultHttpContext());

            Assert.IsNotNull(model);
            Assert.AreEqual(model.ErrorMessage.Trim(), "Unknown Error".Trim());
        }

        /* To Do : 
          * Should Add more test here and for GlobalErrorHandler
          *  More Test for fetaure and in service class (for WeatherService and CityService)       
          */
    }
}
