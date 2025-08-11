using CryptocurrencyPlatform.Application.DTOs.Response;
using CryptocurrencyPlatform.Domain.Entities;
using CryptocurrencyPlatform.Domain.Interfaces.Services;
using Newtonsoft.Json;

namespace CryptocurrencyPlatform.Infrastructure.Services {
    public class AssetService(HttpClient httpClient) : IAssetService {
        public async Task<List<AssetEntity>> GetById(string Ids, CancellationToken cancellationToken) {
            var asset = await httpClient.GetAsync($"{httpClient.BaseAddress}/assets?ids={Ids}", cancellationToken)
                       ?? throw new Exception("Failed to fetch asset");

            var content = await asset.Content.ReadAsStringAsync(cancellationToken);


            var entity = JsonConvert.DeserializeObject<DefaultResponseDto<AssetEntity>>(content)
                         ?? throw new Exception("Failed to deserialize asset");

            return entity.Data;
        }
    }
}
