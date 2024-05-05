using MassTransit;
using WebshopService.API.Models;

namespace WebshopService.API.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IBus _bus;
        public ItemsService(IBus bus) 
        { 
            _bus = bus;
        }
        public async Task<Guid> AddItem(Item item)
        {
            await _bus.Publish(item);
            return item.Id;
        }

        public Task DeleteItem(Guid item)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemById(Guid itemId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetItems(int pageNo, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
