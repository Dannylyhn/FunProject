using Microsoft.AspNetCore.Mvc;
using WebshopService.API.Extensions;
using WebshopService.API.Models;
using WebshopService.API.Models.DTO;
using WebshopService.API.Services;

namespace WebshopService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebshopServiceController : ControllerBase
    {
        private readonly ILogger<WebshopServiceController> _logger;
        private readonly IItemsService _itemsService;

        public WebshopServiceController(ILogger<WebshopServiceController> logger,
            IItemsService itemsService)
        {
            _logger = logger;
            _itemsService = itemsService;
        }

        [HttpPost("AddItem")]
        public async Task<IActionResult> AddItem([FromBody] ItemDTO item)
        {
            await _itemsService.AddItem(item.MapItem());
            return Ok();
        }
    }
}
