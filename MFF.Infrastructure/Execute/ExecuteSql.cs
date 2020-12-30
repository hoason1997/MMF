using MFF.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.Infrastructure.Execute
{
    public class ExecuteSql : IExecuteSql
    {
        //private readonly MFFDbContext appDbContext;
        private readonly MFFDbContext appDbContext;
        //public ExecuteSql(MFFDbContext appDbContext)
        public ExecuteSql(MFFDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IQueryable<TModel> FromSqlRaw<TModel>([NotNull] string sql, [NotNull] params object[] parameters) where TModel : class
        {
            return appDbContext.Set<TModel>().FromSqlRaw(sql, parameters);
        }

        public async Task<int> ExecuteSqlRawAsync([NotNull] string sql, [NotNull] params object[] parameters)
        {
            return await appDbContext.Database.ExecuteSqlRawAsync(sql, parameters);
        }
    }
}
