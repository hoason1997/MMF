using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.Infrastructure
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache distributedCache;
        public RedisCacheService(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public async Task<TModel> GetAsync<TModel>(string key)
        {
            var value = await distributedCache.GetStringAsync(key);
            if (string.IsNullOrEmpty(value))
                return default(TModel);

            return JsonConvert.DeserializeObject<TModel>(value);
        }

        public async Task SetAsync<TModel>(string key, TModel value, int? expiresInMinutes = null)
        {
            var options = new DistributedCacheEntryOptions();
            if (expiresInMinutes.HasValue)
            {
                options = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(expiresInMinutes.Value));
            }

            await distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(value), options);
        }

        public async Task RemoveAsync(string key) => await distributedCache.RemoveAsync(key);

        public async Task RemoveAsync(IEnumerable<string> keys) => await Task.WhenAll(keys.Select(x => distributedCache.RemoveAsync(x)));

        public void Remove(string key) => distributedCache.Remove(key);

        public void Remove(IEnumerable<string> keys)
        {
            foreach (var key in keys)
            {
                distributedCache.Remove(key);
            }
        }
    }
}
