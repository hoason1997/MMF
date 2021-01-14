using Autofac.Util;
using Microsoft.EntityFrameworkCore;
using System;

namespace MFF.ERPAPI.Factories
{
    public interface IDbFactory<TContext> : IDisposable where TContext : DbContext, new()
    {
        TContext Init();
    }

    public class DbFactory<TContext> : Disposable, IDbFactory<TContext> where TContext : DbContext, new()
    {
        TContext _dbContext;

        public TContext Init()
        {
            return _dbContext ?? (_dbContext = new TContext());
        }

        protected virtual void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
