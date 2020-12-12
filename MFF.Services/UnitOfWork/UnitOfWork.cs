using MFF.Data;
using MFF.Data.NHCH;
using MFF.DTO.BaseEntities;
using MFF.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IServiceProvider serviceProvider;
        //public readonly MFFDbContext dbContext;
        public readonly CauHoiDB dbContext;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        private bool disposed = false;

        public Dictionary<Type, object> Repositories
        {
            get { return repositories; }
            set { Repositories = value; }
        }

        //public UnitOfWork(MFFDbContext dbContext
        public UnitOfWork(CauHoiDB dbContext
            , IServiceProvider serviceProvider)
        {
            this.dbContext = dbContext;
            this.serviceProvider = serviceProvider;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : Entity
        {
            if (Repositories.Keys.Contains(typeof(TEntity)))
            {
                return Repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            var repo = serviceProvider.GetRequiredService<IRepository<TEntity>>();
            Repositories.Add(typeof(TEntity), repo);
            return repo;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            disposed = true;
        }
    }
}
