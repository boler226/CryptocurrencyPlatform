using System.Net;

namespace CryptocurrencyPlatform.Infrastructure.Exceptions.Exception.Unauthorized {
    public class UnauthorizedException : BaseException {
        public UnauthorizedException() 
            : base ("Unauthorized", HttpStatusCode.Unauthorized) { 
        }
    }
}
