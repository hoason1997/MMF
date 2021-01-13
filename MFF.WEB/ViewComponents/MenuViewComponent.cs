using MFF.Infrastructure.Models;
using MFF.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace MFF.WEB.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IMenuService _service;

        public MenuViewComponent(IMenuService service)
        {
            _service = service;
        }

        public IViewComponentResult Invoke()
        {
            var menuViewModel = new MenuViewModel
            {
                MenuItems = _service.GetMenuByUser(User)
            };

            return View(menuViewModel);
        }
    }
}
