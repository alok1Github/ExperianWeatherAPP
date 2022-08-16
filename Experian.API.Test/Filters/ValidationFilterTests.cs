using Experian.API.Test;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Experian.API.Filters
{
    [TestClass]
    public class ValidationFilterTests
    {
        private ValidationFilter _filter;
        private ActionExecutingContext _executingContext;

        [TestInitialize]
        public void SetUp()
        {
            _filter = new ValidationFilter();

            Helper.ActionContext();
            _executingContext = Helper.ActionExecutingContext();
        }

        [TestMethod]
        public void Returns_BadRequest_For_Error_In_ModelState()
        {
            _executingContext.ModelState.AddModelError("error", "Test Error");

            _filter.OnActionExecuting(_executingContext);

            Assert.IsNotNull(_executingContext.Result);
            Assert.AreEqual(typeof(BadRequestObjectResult), _executingContext.Result.GetType());
        }

        [TestMethod]
        public void Returns_Null_Action_Context_For_ValidModel()
        {
            _filter.OnActionExecuting(_executingContext);

            Assert.IsNull(_executingContext.Result);
        }
    }
}
