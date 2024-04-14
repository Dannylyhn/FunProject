using ServiceStack.Redis;
using System.Formats.Asn1;
using static ServiceStack.Diagnostics.Events;

namespace CacheService.Services
{
    public class CacheService : ICacheService
    {
        public readonly IRedisClientsManager RedisClientsManager;
        public readonly string TestKey = "Key";

        public CacheService(IRedisClientsManager redisClientsManager)
        {
            RedisClientsManager = redisClientsManager;
        }

        public async Task<object> GetCache(string key)
        {
            await using var redisAsync = await RedisClientsManager.GetClientAsync();
            var cachedValue = await redisAsync.GetAsync<object>(key);
            if (cachedValue == null) throw new ArgumentNullException(nameof(cachedValue));
            return cachedValue;

        }
        public async Task SetCache(string key, object value)
        {
            await using var redisAsync = await RedisClientsManager.GetClientAsync();
            await redisAsync.SetAsync(key, value);
        }

    }
}
