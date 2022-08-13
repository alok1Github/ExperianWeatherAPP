using Microsoft.AspNetCore.Diagnostics;
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
            // To Do : Error handling can be enhanced with different and more specific exceptions
            //         also can be divided into various category in exception type
            var exceptionType = exception.GetType();

            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }

            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(ExceptionResponseBuilder.createRespone(exceptionHandlerPathFeature?.Error, context));

            return context.Response.WriteAsync(result);
        }
    }
}

