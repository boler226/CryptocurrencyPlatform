namespace CryptocurrencyPlatform.Domain.Entities {
    public class AssetEntity {
        public string Id { get; set; } = null!;
        public string Rank { get; set; } = null!;
        public string Symbol { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Supply { get; set; }
        public decimal? MaxSupply { get; set; }
        public decimal MarketCapUsd { get; set; }
        public decimal VolumeUsd24Hr { get; set; }
        public decimal PriceUsd { get; set; }
        public decimal ChangePercent24Hr { get; set; }
        public decimal? Vwap24Hr { get; set; }
        public string Explorer { get; set; } = null!;
        public Dictionary<string, List<string>>? Tokens { get; set; } = new();
    }
}
