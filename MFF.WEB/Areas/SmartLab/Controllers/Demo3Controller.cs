using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Controllers
{
    [Area("SmartLab")]
    public class Demo3Controller : Controller
    {
        // GET: Demo3Controller
        public ActionResult Index()
        {
            return View();
        }

        // GET: Demo3Controller/Details/5
        public ActionResult Add(int id)
        {
            return View();
        }

        // GET: Demo3Controller/Create
        public ActionResult Grid()
        {
            return View();
        }

        // POST: Demo3Controller/Create
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

        // GET: Demo3Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Demo3Controller/Edit/5
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

        // GET: Demo3Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Demo3Controller/Delete/5
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
