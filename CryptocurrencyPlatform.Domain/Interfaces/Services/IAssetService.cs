using CryptocurrencyPlatform.Domain.Entities;

namespace CryptocurrencyPlatform.Domain.Interfaces.Services {
    public interface IAssetService {
        Task<List<AssetEntity>> GetById(string Id, CancellationToken cancellationToken);
    }
}
