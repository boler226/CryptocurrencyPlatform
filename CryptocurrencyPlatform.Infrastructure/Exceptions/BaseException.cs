using System.Net;

namespace CryptocurrencyPlatform.Infrastructure.Exceptions {
    public class BaseException : System.Exception {
        public HttpStatusCode StatusCode { get; }
        public BaseException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : base(message) {
            StatusCode = statusCode;
        }
    }
}
