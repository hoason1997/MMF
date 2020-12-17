using MFF.DTO.Helpers;
using MFF.Infrastructure.Models;
using MFF.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace MFF.WEB.Controllers
{
    [Area("NHCH")]
    public class CauHoiController : Controller
    {
        private readonly ICauHoiService _cauHoiService;
        public CauHoiController(ICauHoiService cauHoiService)
        {
            _cauHoiService = cauHoiService;
        }
        // GET: CauHoiController
        [ProducesResponseType(typeof(SuccessResponseModel<CauHoiModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Index()
        {
            var result = await _cauHoiService.GetPagingAsync(1,10);
            if (result!=null)
            {
                ViewBag.Count = result.Count;
                return View(result.Items);
            }
            else
            {
                return View();
            }
            //return API structure
            // return ResponseHelper.Success(result);
        }


        public async Task<ActionResult> Search(string keyword, int size = 10, int page = 1)
        {
            var result = await _cauHoiService.GetPagingAsync(keyword: keyword, index: page, size: size, orderCol: null, orderType: null);
            if (result != null)
            {
                ViewBag.Count = result.Count;
                return RedirectToAction("Index", result.Items);
            }
            else
            {
                return View();
            }
            //return API structure
            // return ResponseHelper.Success(result);
        }
        // GET: CauHoiController/Details/5
        [ProducesResponseType(typeof(SuccessResponseModel<CauHoiDetailModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Details(int id)
        {
            var result = await _cauHoiService.GetOneAsync(x=>x.CauHoiID==id);
            return ResponseHelper.Success(result);
        }

        // GET: CauHoiController/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Grid()
        {
            return View();
        }

        // POST: CauHoiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            return View();
        }

        // GET: CauHoiController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CauHoiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CauHoiController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CauHoiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
