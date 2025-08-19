using CryptocurrencyPlatform.Domain.Entities;

namespace CryptocurrencyPlatform.Domain.Interfaces.Services {
    public interface IRateService {
        Task<RateEntity> GetById(string slug, CancellationToken cancellationToken);
        Task<List<RateEntity>> GetList(string? ids, CancellationToken cancellationToken);
    }
}
