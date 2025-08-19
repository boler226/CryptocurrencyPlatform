namespace CryptocurrencyPlatform.Domain.Entities {
    public class RateEntity {
        public string Id { get; set; } = null!;
        public string Symbol { get; set; } = null!;
        public string CurrencySymbol { get; set; } = null!;
        public string Type { get; set; } = null!;
        public decimal RateUsd { get; set; }
    }
}
