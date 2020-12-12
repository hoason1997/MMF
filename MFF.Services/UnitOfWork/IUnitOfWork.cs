using MFF.DTO.BaseEntities;
using MFF.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace MFF.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : Entity;
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
