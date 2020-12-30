  using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Controllers
{
    [Area("SmartLab")]
    public class Demo2Controller : Controller
    {
        // GET: Demo2
        public ActionResult Index()
        {
            return View();
        }

        // GET: Demo2/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Demo2/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Demo2/Create
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

        // GET: Demo2/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        public ActionResult Grid(int id)
        {
            return View();
        }

        // POST: Demo2/Edit/5
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

        // GET: Demo2/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Demo2/Delete/5
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
