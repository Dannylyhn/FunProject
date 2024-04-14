using CacheService.Models;
using CacheService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CacheService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CacheServiceController : ControllerBase
    {
        private readonly ILogger<CacheServiceController> _logger;
        private readonly ICacheService _cacheService;

        public CacheServiceController(ILogger<CacheServiceController> logger,
            ICacheService cacheService)
        {
            _logger = logger;
            _cacheService = cacheService;
        }

        [HttpPost("GetCache")]
        public async Task<IActionResult> GetCache([FromBody] string key)
        {
            try
            {
                var cache = await _cacheService.GetCache(key);
                if(cache == null) return NotFound();
                return Ok(cache);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error with retriving cache based on key: {@0}", key);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveCache")]
        public async Task<IActionResult> SaveCache(CacheDTO request)
        {
            try
            {
                await _cacheService.SetCache(request.Key, request.Payload);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error setting new cache based on request: {@0}", request);
                return BadRequest(ex.Message);
            }
        }
    }
}
