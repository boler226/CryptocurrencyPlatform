using CryptocurrencyPlatform.Domain.Entities;

namespace CryptocurrencyPlatform.Domain.Interfaces.Services {
    public interface IRateService {
        Task<RateEntity> GetByIdAsync(string slug, CancellationToken cancellationToken);
        Task<List<RateEntity>> GetListAsync(string? ids, CancellationToken cancellationToken);
    }
}
