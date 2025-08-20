using CryptocurrencyPlatform.Infrastructure.Exceptions.Delegation.Unauthorized;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CryptocurrencyPlatform.Infrastructure.Extensions {
    public static class CoincapClientExtensions {
        public static void ConfigureCoincapClient(this HttpClient httpClient, IConfiguration configuration) {
            httpClient.BaseAddress = new Uri("https://rest.coincap.io/v3");
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", configuration["BearerAuth:Value"]);
        }

        public static IServiceCollection AddCoincapClient<TClient, TImplementation>(
            this IServiceCollection services, IConfiguration configuration)
            where TClient : class
            where TImplementation : class, TClient {
            services.AddHttpClient<TClient, TImplementation>(client => {
                client.ConfigureCoincapClient(configuration);
            })
            .AddHttpMessageHandler<UnauthorizedDelegatingHandler>();

            return services;
        }
    }
}
