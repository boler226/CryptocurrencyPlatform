using CryptocurrencyPlatform.Application.DTOs.Response;
using CryptocurrencyPlatform.Domain.Entities;
using CryptocurrencyPlatform.Domain.Interfaces.Services;
using Newtonsoft.Json;

namespace CryptocurrencyPlatform.Infrastructure.Services {
    public class AssetService(HttpClient httpClient) : IAssetService {
        public async Task<AssetEntity> GetById(string slug, CancellationToken cancellationToken) {
            var asset = await httpClient.GetAsync($"{httpClient.BaseAddress}/assets/{slug}", cancellationToken)
                        ?? throw new Exception("Failed to fetch asset");

            var content = await asset.Content.ReadAsStringAsync(cancellationToken);

            var entity = JsonConvert.DeserializeObject<DefaultResponseDto<AssetEntity>>(content)
                         ?? throw new Exception("Failed to deserialize asset");

            return entity.Data;
        }

        public async Task<List<AssetEntity>> GetList(string? ids, CancellationToken cancellationToken, int limit = 100, int offset = 0) {            
            var assets = await httpClient.GetAsync($"{httpClient.BaseAddress}/assets?ids={ids}&limit={limit}&offset={offset}", cancellationToken)
                       ?? throw new Exception("Failed to fetch asset");

            var content = await assets.Content.ReadAsStringAsync(cancellationToken);


            var entity = JsonConvert.DeserializeObject<DefaultListResponseDto<AssetEntity>>(content)
                         ?? throw new Exception("Failed to deserialize asset");

            return entity.Data;
        }
    }
}
