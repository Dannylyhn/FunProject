using WebshopService.API.Models;

namespace WebshopService.API.Services
{
    public interface IItemsService
    {
        public Task<List<Item>> GetItems(int pageNo, int pageSize);
        public Task<Guid> AddItem(Item item);
        public Task DeleteItem (Guid item);
        public Task<Item> GetItemById(Guid itemId);
    }
}
