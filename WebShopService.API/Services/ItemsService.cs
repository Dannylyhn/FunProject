using MassTransit;
using WebshopService.API.Models;

namespace WebshopService.API.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public ItemsService(IPublishEndpoint publishEndpoint) 
        { 
            _publishEndpoint = publishEndpoint;
        }
        public async Task<Guid> AddItem(Item item)
        {
            await _publishEndpoint.Publish(new Message { Id = new Guid(), Body = "Testing", Title = "Testtitle"});
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
