using MFF.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Controllers
{
    [Area("SmartLab")]
    [Route(Constants.BCKNKetQuaPhanTichHangNgay)]
    public class BCKNKetQuaPhanTichHangNgayController : Controller
    {
        [Route(Constants.ViewData)]
        // GET: BCKN_KetQuaPhanTichHangNgayController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BCKN_KetQuaPhanTichHangNgayController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BCKN_KetQuaPhanTichHangNgayController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BCKN_KetQuaPhanTichHangNgayController/Create
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

        // GET: BCKN_KetQuaPhanTichHangNgayController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BCKN_KetQuaPhanTichHangNgayController/Edit/5
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

        // GET: BCKN_KetQuaPhanTichHangNgayController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BCKN_KetQuaPhanTichHangNgayController/Delete/5
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
