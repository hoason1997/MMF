using MFF.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Controllers
{
    [Route(Constants.NSLBCPCauHinhTheTichBCP)]
    [Area("SmartLab")]
    public class NSLBCPCauHinhTheTichBCPController : Controller
    {
        [Route(Constants.ViewData)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
