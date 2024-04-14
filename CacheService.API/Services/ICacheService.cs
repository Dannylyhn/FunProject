namespace CacheService.Services
{
    public interface ICacheService
    {
        public Task SetCache(string key, object value);
        public Task<object> GetCache(string value);

    }
}
