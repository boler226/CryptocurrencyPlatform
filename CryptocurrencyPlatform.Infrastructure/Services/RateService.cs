using CryptocurrencyPlatform.Application.DTOs.Response;
using CryptocurrencyPlatform.Domain.Entities;
using CryptocurrencyPlatform.Domain.Interfaces.Services;
using Newtonsoft.Json;

namespace CryptocurrencyPlatform.Infrastructure.Services {
    public class RateService(HttpClient httpClient) : IRateService {
        public async Task<RateEntity> GetByIdAsync(string slug, CancellationToken cancellationToken) {
            var rate = await httpClient.GetAsync($"{httpClient.BaseAddress}/rates/{slug}", cancellationToken)
                       ?? throw new Exception("");

            var content = await rate.Content.ReadAsStringAsync(cancellationToken);

            var entity = JsonConvert.DeserializeObject<DefaultResponseDto<RateEntity>>(content)
                         ?? throw new Exception("Failed to deserialize asset");

            return entity.Data;
        }

        public async Task<List<RateEntity>> GetListAsync(string? ids, CancellationToken cancellationToken) {
            var rates = await httpClient.GetAsync($"{httpClient.BaseAddress}/rates?ids={ids}", cancellationToken)
                                       ?? throw new Exception("");

            var content = await rates.Content.ReadAsStringAsync(cancellationToken);

            var entity = JsonConvert.DeserializeObject<DefaultListResponseDto<RateEntity>>(content)
                         ?? throw new Exception("Failed to deserialize asset");

            return entity.Data;
        }
    }
}
