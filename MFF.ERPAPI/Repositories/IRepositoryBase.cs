using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MFF.ERPAPI.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql">
        /// The column names in our result must match the column names that the properties are mapped to
        /// Our query must return data for all properties of the entity or query type
        /// The SQL query can’t contain relationships, but we can always combine FromSqlRaw with the Include method
        /// </param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<TEntity> Query(string sql, params object[] parameters);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="include"></param>
        /// <param name="noTracking">
        /// When we write only read-only queries in Entity Framework Core(the result of the query won’t be used for any additional database modification), 
        /// we should always add AsNoTracking method to speed up the execution.
        /// </param>
        /// <returns></returns>
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
            , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            , bool noTracking = false);
        void Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
        Task AddAsync(TEntity entity);
        Task AddAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<bool> CheckExistsAsync(Expression<Func<TEntity, bool>> predicate);
    }
}


