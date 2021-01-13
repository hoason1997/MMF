using AutoMapper;
using MFF.DTO.BaseEntities;
using MFF.DTO.Constants;
using MFF.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MFF.Infrastructure
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class, IBaseEntity
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        protected readonly IRedisCacheService redisCache;
        public Service(IUnitOfWork unitOfWork
            , IMapper mapper
            , IRedisCacheService redisCache
            , IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.redisCache = redisCache;
            this.httpContextAccessor = httpContextAccessor;
        }
        public virtual TModel Add<TModel>(TModel entry)
        {
            if (entry == null)
                return default(TModel);

            var entity = mapper.Map<TEntity>(entry);
            entity.TaoBoi = entity.CapNhatBoi = LogedInUserId;
            entity.NgayTao = entity.NgayCapNhat = DateTime.UtcNow;
            unitOfWork.Repository<TEntity>().Add(entity);
            var saveResult = unitOfWork.SaveChanges();

            if (saveResult > 0)
            {
                var key = $"{typeof(TEntity).Name}_all";
                redisCache.Remove(key);

                return mapper.Map<TModel>(entity);
            }

            throw new Exception();
        }
        public virtual IEnumerable<TModel> Add<TModel>(IEnumerable<TModel> entries)
        {
            if (entries == null || entries.Count() == 0)
                return null;

            var entities = entries.Select(x => mapper.Map<TEntity>(x)).ToList();
            entities.ForEach(x =>
            {
                x.TaoBoi = x.CapNhatBoi = LogedInUserId;
                x.NgayTao = x.NgayCapNhat = DateTime.UtcNow;
            });
            unitOfWork.Repository<TEntity>().Add(entities);
            var saveResult = unitOfWork.SaveChanges();

            if (saveResult > 0)
            {
                var key = $"{typeof(TEntity).Name}_all";
                redisCache.Remove(key);

                return entities.Select(x => mapper.Map<TModel>(x));
            }

            throw new Exception();
        }
        public virtual async Task<TModel> AddAsync<TModel>(TModel entry)
        {
            if (entry == null)
                return default(TModel);

            var entity = mapper.Map<TEntity>(entry);
            entity.TaoBoi = entity.CapNhatBoi = LogedInUserId;
            entity.NgayTao = entity.NgayCapNhat = DateTime.UtcNow;
            await unitOfWork.Repository<TEntity>().AddAsync(entity);
            var saveResult = await unitOfWork.SaveChangesAsync();

            if (saveResult > 0)
            {
                var key = $"{typeof(TEntity).Name}_all";
                await redisCache.RemoveAsync(key);
                return mapper.Map<TModel>(entity);
            }

            throw new Exception();
        }
        public virtual async Task<TModel> AddAsync<TModel>(TModel entry, string[] keyRedisCache = null)
        {
            if (entry == null)
                return default(TModel);

            var entity = mapper.Map<TEntity>(entry);
            entity.TaoBoi = entity.CapNhatBoi = LogedInUserId;
            entity.NgayTao = entity.NgayCapNhat = DateTime.UtcNow;
            await unitOfWork.Repository<TEntity>().AddAsync(entity);
            var saveResult = await unitOfWork.SaveChangesAsync();

            if (saveResult > 0)
            {
                List<Task> tasks = new List<Task>();
                tasks.Add(redisCache.RemoveAsync($"{typeof(TEntity).Name}_all"));
                if (keyRedisCache != null)
                {
                    foreach (var item in keyRedisCache)
                    {
                        tasks.Add(redisCache.RemoveAsync(item));
                    }
                }
                await Task.WhenAll(tasks);
                return mapper.Map<TModel>(entity);
            }

            throw new Exception();
        }
        public virtual async Task<IEnumerable<TModel>> AddAsync<TModel>(IEnumerable<TModel> entries)
        {
            if (entries == null || entries.Count() == 0)
                return null;

            var entities = entries.Select(x => mapper.Map<TEntity>(x)).ToList();
            entities.ForEach(x =>
            {
                x.TaoBoi = x.CapNhatBoi = LogedInUserId;
                x.NgayTao = x.NgayCapNhat = DateTime.UtcNow;
            });
            await unitOfWork.Repository<TEntity>().AddAsync(entities);
            var saveResult = await unitOfWork.SaveChangesAsync();

            if (saveResult > 0)
            {
                var key = $"{typeof(TEntity).Name}_all";
                await redisCache.RemoveAsync(key);

                return entities.Select(x => mapper.Map<TModel>(x));
            }

            throw new Exception();
        }
        public virtual IEnumerable<TModel> Update<TModel>(IEnumerable<TModel> entries)
        {
            if (entries == null || entries.Count() == 0)
                return null;

            var entities = entries.Select(x => mapper.Map<TEntity>(x)).ToList();
            entities.ForEach(x =>
            {
                x.TaoBoi = x.CapNhatBoi = LogedInUserId;
                x.NgayTao = x.NgayCapNhat = DateTime.UtcNow;
            });
             unitOfWork.Repository<TEntity>().Update(entities);
            var saveResult =  unitOfWork.SaveChanges();

            if (saveResult > 0)
            {
                var key = $"{typeof(TEntity).Name}_all";            
                return entities.Select(x => mapper.Map<TModel>(x));
            }

            throw new Exception();
        }
        public virtual TModel Update<TModel>(string id, TModel entry)
        {
            if (entry == null)
                return default(TModel);

            var entity = unitOfWork.Repository<TEntity>().Query().FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                var entityUpdate = mapper.Map(entry, entity);
                entityUpdate.Id = id;
                entityUpdate.NgayCapNhat = DateTime.UtcNow;
                entityUpdate.CapNhatBoi = LogedInUserId;
                unitOfWork.Repository<TEntity>().Update(entityUpdate);
                var saveResult = unitOfWork.SaveChanges();

                if (saveResult > 0)
                {
                    redisCache.Remove($"{typeof(TEntity).Name}_{id}");
                    redisCache.Remove($"{typeof(TEntity).Name}_all");
                    return mapper.Map<TModel>(entityUpdate);
                }

                throw new Exception();
            }

            throw new MethodAccessException(MessageConstant.NOT_FOUND_RESPONSE);
        }
        public virtual async Task<TModel> UpdateAsync<TModel>(string id, TModel entry)
        {
            if (entry == null)
                return default(TModel);

            var entity = await unitOfWork.Repository<TEntity>().Query().FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                var entityUpdate = mapper.Map(entry, entity);
                entityUpdate.NgayCapNhat = DateTime.UtcNow;
                entityUpdate.CapNhatBoi = LogedInUserId;
                entityUpdate.Id = id;
                unitOfWork.Repository<TEntity>().Update(entityUpdate);
                var saveResult = await unitOfWork.SaveChangesAsync();

                if (saveResult > 0)
                {
                    await Task.WhenAll(
                        redisCache.RemoveAsync($"{typeof(TEntity).Name}_{id}"),
                        redisCache.RemoveAsync($"{typeof(TEntity).Name}_all")
                    );
                    return mapper.Map<TModel>(entityUpdate);
                }

                throw new Exception();
            }

            throw new MethodAccessException(MessageConstant.NOT_FOUND_RESPONSE);
        }
        public virtual async Task<TModel> UpdateAsync<TModel>(string id, TModel entry, string[] keyRedisCache = null)
        {
            if (entry == null)
                return default(TModel);

            var entity = await unitOfWork.Repository<TEntity>().Query().FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                var entityUpdate = mapper.Map(entry, entity);
                entityUpdate.NgayCapNhat = DateTime.UtcNow;
                entityUpdate.CapNhatBoi = LogedInUserId;
                //entityUpdate.Id = id;
                unitOfWork.Repository<TEntity>().Update(entityUpdate);
                var saveResult = await unitOfWork.SaveChangesAsync();

                if (saveResult > 0)
                {
                    List<Task> tasks = new List<Task>();
                    tasks.Add(redisCache.RemoveAsync($"{typeof(TEntity).Name}_{id}"));
                    tasks.Add(redisCache.RemoveAsync($"{typeof(TEntity).Name}_all"));
                    if (keyRedisCache != null)
                    {
                        foreach (var item in keyRedisCache)
                        {
                            tasks.Add(redisCache.RemoveAsync(item));
                        }
                    }
                    await Task.WhenAll(tasks);
                    return mapper.Map<TModel>(entityUpdate);
                }

                throw new Exception();
            }

            throw new MethodAccessException(MessageConstant.NOT_FOUND_RESPONSE);
        }
        protected string LogedInUserId => httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
    }
}
