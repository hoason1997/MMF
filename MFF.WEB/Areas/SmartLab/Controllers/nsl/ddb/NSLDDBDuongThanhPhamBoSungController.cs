using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Controllers
{
    [Area("SmartLab")]
    public class NSLDDBDuongThanhPhamBoSungController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewListData()
        {
            return View();
        }
    }
}
