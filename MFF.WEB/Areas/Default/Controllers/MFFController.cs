using MFF.DTO.BaseEntities;
using MFF.Infrastructure;
using MFF.WEB.Models.MFF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MFF.WEB.Controllers
{
    public class MFFController : Controller
    {
        private readonly IMFFItemService _MFFItemService;

        public MFFController(IMFFItemService MFFItemService)
        {
            this._MFFItemService = MFFItemService ?? throw new ArgumentNullException(nameof(MFFItemService));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await _MFFItemService.GetItemsAsync();
            return View(items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            await _MFFItemService.AddItemAsync(new MFFItem() { Name = model.Name });
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var item = await _MFFItemService.GetAsync(id);

            if (item == null)
                return NotFound();

            var model = new UpdateViewModel() { Id = item.Id, Name = item.Name };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            await _MFFItemService.UpdateItemAsync(new MFFItem() { Id = model.Id, Name = model.Name });
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _MFFItemService.GetAsync(id);

            if (item == null)
                return NotFound();

            var model = new DeleteViewModel() { Id = item.Id, Name = item.Name };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteViewModel model)
        {
            await _MFFItemService.DeleteItemAsync(model.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}