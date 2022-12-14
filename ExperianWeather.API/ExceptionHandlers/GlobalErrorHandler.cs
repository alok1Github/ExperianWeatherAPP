using Newtonsoft.Json;
using System.Net;

namespace Experian.API.ExceptionHandlers
{
    public class GlobalErrorHandler
    {
        private readonly RequestDelegate _next;
        public GlobalErrorHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception exception)
        {
            // To Do : Error handling can be enhanced further with different and more specific exceptions
            //         also can be divided into various category in exception type (based on http Status code)

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(ExceptionResponseBuilder.createRespone(exception, context));

            return context.Response.WriteAsync(result);
        }
    }
}

