namespace CryptocurrencyPlatform.WPF.DTOs.Rate {
    public class RateDto {
        public string Symbol { get; set; } = null!;
        public string CurrencySymbol { get; set; } = null!;
        public string Type { get; set; } = null!;
        public decimal RateUsd { get; set; }
    }
}
