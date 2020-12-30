using AutoMapper;
using AutoMapper.QueryableExtensions;
using MFF.Infrastructure.Paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.Infrastructure.Extensions
{
    public static class IQueryablePaginateExtensions
    {
        public static async Task<IPagination<TModel>> ToPaginateAsync<TEntity, TModel>(this IQueryable<TEntity> source, IMapper mapper = null
            , int? index = null
            , int? size = null
            , int from = 0)
        {
            if (index.HasValue && from > index.Value) throw new ArgumentException($"From: {from} > Index: {index.Value}, must From <= Index");

            var count = await  source.CountAsync();

            if (index.HasValue && size.HasValue)
            {
                index -= 1;
                source = source.Skip((index.Value - from) * size.Value).Take(size.Value);
            }
            var items = await source.ProjectTo<TModel>(mapper.ConfigurationProvider).ToListAsync();

            var list = new Pagination<TModel>
            {
                Index = index,
                Size = size,
                From = from,
                Count = count,
                Items = items
            };

            if (index.HasValue)
                list.Index += 1;

            if (size.HasValue)
                list.Pages = (int)Math.Ceiling(count / (double)size);

            return list;
        }
    }
}
