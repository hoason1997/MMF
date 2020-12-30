using MFF.DTO.Entities.Identity;
using System.Collections.Generic;
using System.Security.Principal;

namespace MFF.Infrastructure.Services
{
    public interface IMenuService
    {
        public List<MenuItem> GetMenuByUser(IPrincipal user);
    }
}