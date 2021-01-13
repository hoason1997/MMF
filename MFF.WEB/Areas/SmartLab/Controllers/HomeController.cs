using MFF.WEB.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MFF.WEB.Controllers
{
    [Area("SmartLab")]
    public class HomeController : Controller
    {
        public readonly IInitData _initservice;
        public HomeController(IInitData initservice)
        {
            _initservice = initservice;
        }
        // GET: HomeController
        //public ActionResult Index()
        //{
        //    try
        //    {
        //        //    _initservice.InitBasedata();
        //    }
        //    catch (System.Exception ex)
        //    {

        //        throw;
        //    }
        //    //  
        //    return View();
        //}
        //[HttpPost]
        public async Task<IActionResult> Index()
        {
            await _initservice.InitBasedata();
            return View();
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
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

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
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
