using MFF.DTO.BaseEntities;
using MFF.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace MFF.Infrastructure.UnitOfWork
{
    public interface IUnitOfWorkBHSTA
    {
        IBaseRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity;
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
