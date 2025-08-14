using CryptocurrencyPlatform.Domain.Entities;
using System.Collections.Generic;

namespace CryptocurrencyPlatform.Domain.Interfaces.Services {
    public interface IAssetService {
        Task<AssetEntity> GetById(string slug, CancellationToken cancellationToken);
        Task<List<AssetEntity>> GetList(string? ids, CancellationToken cancellationToken, int limit = 100, int offset = 0);
    }
}
