using MFF.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MFF.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TEntity, TContext> where TEntity : class where TContext : DbContext, new()
    {
        #region Properties
        private TContext _dataContext;
        private readonly DbSet<TEntity> _dbSet;

        protected IDbFactory<TContext> DbFactory
        {
            get;
            private set;
        }

        protected TContext dbContext
        {
            get { return _dataContext ?? (_dataContext = this.DbFactory.Init()); }
        }
        #endregion

        protected RepositoryBase(IDbFactory<TContext> dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = dbContext.Set<TEntity>();
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
            IQueryable<TEntity> query = _dbSet;
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
        public void Delete(Expression<Func<TEntity, bool>> predicate) => dbContext.RemoveRange(_dbSet.Where(predicate));

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null) => predicate == null ? await _dbSet.CountAsync() : await _dbSet.CountAsync(predicate);
        public async Task<bool> CheckExistsAsync(Expression<Func<TEntity, bool>> predicate) => await _dbSet.AnyAsync(predicate);
    }
}
