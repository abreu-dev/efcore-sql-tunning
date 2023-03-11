using System.Diagnostics;
using System.Text.Json;

namespace Tunning.WebApi.Scope.Middlewares
{
    internal sealed class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            await TreatExceptionAsync(httpContext, exception);
        }

        private static async Task TreatExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var response = new
            {
                type = "InternalServerError",
                error = "Internal Server Error",
                detail = exception.Message,
                instance = httpContext.Request.Path.Value,
                traceId = Activity.Current?.TraceId.ToString()
            };

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
