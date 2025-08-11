using CryptocurrencyPlatform.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CryptocurrencyPlatform.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class AssetsController(IAssetService service) : ControllerBase {
        [HttpGet("{ids}")]
        public async Task<IActionResult> GetById(string ids, CancellationToken cancellationToken) =>
            Ok(await service.GetById(ids, cancellationToken));
    }
}
