using MFF.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Controllers
{
    [Area("SmartLab")]
    [Route(Constants.QTHTDanhMucChucNang)]
    public class QTHTDanhMucChucNangController : Controller
    {
        [Route(Constants.ViewData)]
        public IActionResult Index()
        {
            return View();
        }
        [Route(Constants.CreateForm)]
        public IActionResult AddForm()
        {
            return View();
        }
        [Route(Constants.CreateChildForm)]
        public IActionResult AddChildForm()
        {
            return View();
        }
    }
}
