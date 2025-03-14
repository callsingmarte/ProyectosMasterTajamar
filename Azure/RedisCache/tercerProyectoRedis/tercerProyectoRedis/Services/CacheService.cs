using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Text;
using tercerProyectoRedis.Models;

namespace tercerProyectoRedis.Services
{
    public class CacheService
    {
        private readonly IDistributedCache _cache;

        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task SetCacheAsync(string key, Item item)
        {
            var serializedItem = JsonConvert.SerializeObject(item);
            var encodedItem = Encoding.UTF8.GetBytes(serializedItem);
            await _cache.SetAsync(key, encodedItem, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });
        }

        //Recuperar de la cache
        public async Task<Item> GetCacheAsync(string key)
        {
            var encodedItem = await _cache.GetAsync(key);
            if (encodedItem == null)
            {
                return null;
            }

            var serializedItem = Encoding.UTF8.GetString(encodedItem);

            return JsonConvert.DeserializeObject<Item>(serializedItem)!;
        }

        public async Task SetCacheAsync(string key, List<Item> items)
        {
            var serializedItems = JsonConvert.SerializeObject(items);
            var encodedItems = Encoding.UTF8.GetBytes(serializedItems);
            await _cache.SetAsync(key, encodedItems, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });
        }

        public async Task<List<Item>> GetCacheAsyncList(string key)
        {
            var encodedItems = await _cache.GetAsync(key);
            if (encodedItems == null) return null;
            var serializedItems = Encoding.UTF8.GetString(encodedItems);
            return JsonConvert.DeserializeObject<List<Item>>(serializedItems);
        }
    }
}
