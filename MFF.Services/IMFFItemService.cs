using MFF.DTO.BaseEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MFF.Infrastructure
{
    public interface IMFFItemService
    {
        Task<MFFItem> GetAsync(Guid id);
        Task<IEnumerable<MFFItem>> GetItemsAsync();
        Task AddItemAsync(MFFItem item);
        Task UpdateItemAsync(MFFItem item);
        Task DeleteItemAsync(Guid id);
    }
}
