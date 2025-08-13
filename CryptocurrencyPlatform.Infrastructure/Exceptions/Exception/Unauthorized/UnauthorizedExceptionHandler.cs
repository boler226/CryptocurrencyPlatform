using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Diagnostics;

namespace CryptocurrencyPlatform.Infrastructure.Exceptions.Exception.Unauthorized {
    public class UnauthorizedExceptionHandler(
        ILogger<UnauthorizedException> logger
        ) : IExceptionHandler {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken) {
            if (exception is not UnauthorizedException e)
                return false;

            var problemDetails = new ProblemDetails() {
                Instance = httpContext.Request.Path,
                Title = exception.Message,
            };

            httpContext.Response.StatusCode = (int)e.StatusCode;

            logger.LogError("Unauthorized error: {Message}", exception.Message);
            problemDetails.Status = httpContext.Response.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
