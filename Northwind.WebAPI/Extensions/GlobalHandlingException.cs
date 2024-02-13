
using Northwind.Domain.Exceptions;
using Northwind.Domain.Model;
using System.Text.Json;

namespace Northwind.WebAPI.Extensions
{
    internal sealed class GlobalHandlingException : IMiddleware
    {
        private readonly ILogger<GlobalHandlingException> _logger;

        public GlobalHandlingException(ILogger<GlobalHandlingException> logger)
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

            httpContext.Response.StatusCode = exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            var response = new ErrorModel()
            {
                StatusCode = httpContext.Response.StatusCode,
                Type = exception.GetType().Name,
                Message = exception.Message
            };

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
