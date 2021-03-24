using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Controllers
{
    [Area("SmartLab")]
    public class NSLPKNNSLPTDuongNonLuyenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
