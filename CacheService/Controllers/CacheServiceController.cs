using Microsoft.AspNetCore.Mvc;

namespace CacheService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CacheServiceController : ControllerBase
    {
        private readonly ILogger<CacheServiceController> _logger;

        public CacheServiceController(ILogger<CacheServiceController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetCachedValue")]
        public async Task<IActionResult> GetCache()
        {
            
            return Ok("Hello world");
        }

        [HttpPost("SaveNewCache")]
        public async Task<IActionResult> SaveNewCache()
        {

            return Ok("Hello world");
        }
    }
}
