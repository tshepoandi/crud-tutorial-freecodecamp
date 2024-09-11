using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using TodoAPI.Models;

namespace TodoAPI.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool>
        TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken
        )
        {
            _logger
                .LogError($"An error occurred while processing your request: {
                    exception.Message}");
            var errorResponse =
                new ErrorResponse { Message = exception.Message };
            switch (exception)
            {
                case BadHttpRequestException:
                    errorResponse.statusCode = (int) HttpStatusCode.BadRequest;
                    errorResponse.Title = exception.GetType().Name;
                    break;
                default:
                    errorResponse.statusCode =
                        (int) HttpStatusCode.InternalServerError;
                    errorResponse.Title = "Internal Server Error";
                    break;
            }
            httpContext.Response.StatusCode = errorResponse.statusCode;
            await httpContext
                .Response
                .WriteAsJsonAsync(errorResponse, cancellationToken);
            return true;
        }
    }
}
