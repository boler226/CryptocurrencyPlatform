using CryptocurrencyPlatform.Infrastructure.Exceptions.Exception.Unauthorized;
using Microsoft.Extensions.DependencyInjection;

namespace CryptocurrencyPlatform.Infrastructure.Extensions
{
    public static class ExceptionExtensions {
        public static void AddExceptionHandlers(this IServiceCollection services) {
            services.AddExceptionHandler<UnauthorizedExceptionHandler>();
            services.AddProblemDetails();
        }
    }
}
