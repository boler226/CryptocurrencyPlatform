using CryptocurrencyPlatform.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CryptocurrencyPlatform.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class RatesController(IRateService service) : ControllerBase {
        [HttpGet("{slug}")]
        public async Task<IActionResult> GetById(string slug, CancellationToken cancellationToken) =>
            Ok(await service.GetById(slug, cancellationToken));

        [HttpGet]
        public async Task<IActionResult> GetList(string? ids, CancellationToken cancellationToken) => 
            Ok(await service.GetList(ids, cancellationToken));
    }
}
