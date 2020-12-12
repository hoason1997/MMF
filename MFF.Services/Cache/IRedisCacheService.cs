using System.Collections.Generic;
using System.Threading.Tasks;

namespace MFF.Infrastructure
{
    public interface IRedisCacheService
    {
        Task<TModel> GetAsync<TModel>(string key);
        Task SetAsync<TModel>(string key, TModel value, int? expiresInMinutes = null);
        void Remove(string key);
        void Remove(IEnumerable<string> keys);
        Task RemoveAsync(string key);
        Task RemoveAsync(IEnumerable<string> keys);
    }
}
