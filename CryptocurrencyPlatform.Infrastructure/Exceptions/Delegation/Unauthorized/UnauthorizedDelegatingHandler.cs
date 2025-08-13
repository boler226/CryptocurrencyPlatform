
using CryptocurrencyPlatform.Infrastructure.Exceptions.Exception.Unauthorized;
using System.Net;

namespace CryptocurrencyPlatform.Infrastructure.Exceptions.Delegation.Unauthorized {
    public class UnauthorizedDelegatingHandler : DelegatingHandler {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
                throw new UnauthorizedException();

            return response;
        }
    }
}
