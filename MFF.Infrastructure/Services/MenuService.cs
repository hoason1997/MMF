using MFF.Data.SmartLab;
using MFF.DTO.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace MFF.Infrastructure.Services
{
    public class MenuService : IMenuService
    {
        private readonly SmartLabDBContext _context;
        private readonly UserManager<ApplicationUser> _manager;

        public MenuService(SmartLabDBContext context, UserManager<ApplicationUser> manager)
        {
            _context = context;
            _manager = manager;
        }

        public List<MenuItem> GetMenuByUser(IPrincipal user)
        {
            if (user == null)
            {
                return new List<MenuItem>();
            }

            var principal = user as ClaimsPrincipal;

            var id = _manager.GetUserId(principal);

            var viewableItems = principal.Claims
                .Where(e => e.Value == "View")
                .Select(item => item.Type)
                .ToList();

            var result = _context.MenuItems
                .Where(item => viewableItems.Any(u => item.Id.ToString() == u))
                .ToList();

            return result;
        }
    }
}