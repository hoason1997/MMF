using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.Infrastructure.Execute
{
    public interface IExecuteSql
    {
        IQueryable<TModel> FromSqlRaw<TModel>([NotNull]string sql, [NotNull] params object[] parameters) where TModel : class;
        Task<int> ExecuteSqlRawAsync([NotNull] string sql, [NotNull] params object[] parameters);
    }
}
