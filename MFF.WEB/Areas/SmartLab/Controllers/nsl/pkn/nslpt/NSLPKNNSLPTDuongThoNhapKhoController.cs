using MFF.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Controllers
{
    [Area("SmartLab")]
    [Route(Constants.NSLPKNNSLPTDuongThoNhapKho)]
    public class NSLPKNNSLPTDuongThoNhapKhoController : Controller
    {
        [Route(Constants.AddData)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
