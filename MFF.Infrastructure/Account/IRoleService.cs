using MFF.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MFF.Infrastructure
{
    public interface IRoleService : IService
    {
        Task InitRoles();
        Task InitAdministrationPermissions();
        Task<IEnumerable<RoleItemModel>> GetAll();
        Task<IEnumerable<RoleItemModel>> GetByUser(string userId);
        Task<bool> CheckHasPermission(string userId, string[] inputPermissions);
        Task<IEnumerable<string>> GetPermissionsByUser(string userId);
        Task InitAdminRoles();
    }
}
