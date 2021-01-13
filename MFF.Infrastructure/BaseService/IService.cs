using MFF.DTO.BaseEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MFF.Infrastructure
{
    public interface IService<TEntity>
      where TEntity : IBaseEntity
    {
        TModel Add<TModel>(TModel entry);
        IEnumerable<TModel> Add<TModel>(IEnumerable<TModel> entries);
        Task<TModel> AddAsync<TModel>(TModel entry);
        Task<TModel> AddAsync<TModel>(TModel entry, string[] keyRedisCache = null);
        Task<IEnumerable<TModel>> AddAsync<TModel>(IEnumerable<TModel> entries);

        TModel Update<TModel>(string id, TModel entry);
        IEnumerable<TModel> Update<TModel>(IEnumerable<TModel> entries);
        Task<TModel> UpdateAsync<TModel>(string id, TModel entry);
        Task<TModel> UpdateAsync<TModel>(string id, TModel entry, string[] keyRedisCache = null);
    }
}
