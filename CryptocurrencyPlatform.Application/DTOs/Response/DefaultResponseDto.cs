using System.Text.Json.Serialization;

namespace CryptocurrencyPlatform.Application.DTOs.Response {
    public class DefaultResponseDto<T> {
        [JsonPropertyName("timestamp")]
        public long TimeStamp { get; set; }
        [JsonPropertyName("data")]
        public List<T> Data { get; set; } = new();
    }
}
