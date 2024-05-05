using System.Runtime.CompilerServices;
using WebshopService.API.Models;
using WebshopService.API.Models.DTO;

namespace WebshopService.API.Extensions
{
    public static class ItemExtension
    {
        public static Item MapItem(this ItemDTO item)
        {
            return new Item {
                Id = new Guid(),
                Name = item.Name,
                Description = item.Description,
                Type = item.Type,
            };
        }
    }
}
