namespace CryptocurrencyPlatform.WPF.DTOs.Asset {
    public class AssetCardDto {
        public string Name { get; set; } = null!;
        public string Symbol { get; set; } = null!;
        public decimal PriceUsd { get; set; }
        public string ChangePercent24Hr { get; set; } = null!;
    }
}
