using MFF.Data.SmartLab;
using MFF.DTO.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MFF.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class,IEntity
    {
        //  private readonly MFFDbContext dbContext;
        private readonly SmartLabDBContext dbContext;
        private readonly DbSet<TEntity> dbSet;
        // public Repository(MFFDbContext dbContext)
        public BaseRepository(SmartLabDBContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Query(string sql, params object[] parameters)
        {
            return dbSet.FromSqlRaw(sql, parameters);
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
            , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            , bool noTracking = false)
        {
            IQueryable<TEntity> query = dbSet;
            if (noTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null) return orderBy(query);

            return query;
        }

        public void Add(TEntity entity) => dbContext.Add(entity);
        public void Add(IEnumerable<TEntity> entities) => dbContext.AddRange(entities);
        public async Task AddAsync(TEntity entity) => await dbContext.AddAsync(entity);
        public async Task AddAsync(IEnumerable<TEntity> entities) => await dbContext.AddRangeAsync(entities);
        
        public void Update(TEntity entity) => dbContext.Update(entity);
        public void Update(IEnumerable<TEntity> entities) => dbContext.UpdateRange(entities);

        public void Delete(TEntity entity) => dbContext.Remove(entity);
        public void Delete(IEnumerable<TEntity> entities) => dbContext.RemoveRange(entities);
        public void Delete(Expression<Func<TEntity, bool>> predicate) => dbContext.RemoveRange(dbSet.Where(predicate));

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null) => predicate == null ? await dbSet.CountAsync() : await dbSet.CountAsync(predicate);
        public async Task<bool> CheckExistsAsync(Expression<Func<TEntity, bool>> predicate) => await dbSet.AnyAsync(predicate);
    }
}
