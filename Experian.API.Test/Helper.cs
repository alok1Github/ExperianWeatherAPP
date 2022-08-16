using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Moq;

namespace Experian.API.Test
{
    public static class Helper
    {
        public static ActionContext ActionContext() =>
           new ActionContext(
                   httpContext: new DefaultHttpContext(),
                   routeData: new RouteData(),
                   actionDescriptor: new ActionDescriptor(),
                   modelState: new ModelStateDictionary());

        public static ActionExecutingContext ActionExecutingContext() =>
           new ActionExecutingContext(ActionContext(), new List<IFilterMetadata>(),
                                                 new Dictionary<string, object>(),
                                                 new Mock<Controller>().Object);

        public static ActionExecutedContext ActionExecutedContext() =>
        new ActionExecutedContext(ActionContext(), new List<IFilterMetadata>(),
                                                   new Mock<Controller>().Object
                                                    );
    }
}
