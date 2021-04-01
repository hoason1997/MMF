using MFF.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Controllers
{
    [Area("SmartLab")]
    [Route(Constants.NSLDuongTho)]
    public class NSLDTNhapDuongThoController : Controller
    {
        [Route(Constants.AddData)]
        public IActionResult Index()
        {
            return View();
        }

        [Route(Constants.ViewData)]
        public IActionResult ViewListData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDuongTho(DuongThoUpsertModel duongtho)
        {
            //Dữ liệu nhập vào tuân thủ quy tắc thì cho xử lý
            if (ModelState.IsValid)
            {
                duongtho.MoTa = "Create item perfect";
            }
            return View("Index", duongtho);
        }

        public IActionResult ViewModelData()
        {
            List<DuongThoUpsertModel> a = new List<DuongThoUpsertModel>();
            for (int i = 0; i < 5; i++)
            {
                var b = new DuongThoUpsertModel();
                b.Id = i;
                b.Ngay = DateTime.Now;
                b.MaSoCa = "ABC";
                b.Gio = "12";
                b.TanDuongTho = 11;
                b.LoaiPol = "123";
                b.TanDuongThoTrongNgay = 11;
                b.TongDuongThoTrongCa = 11;
                b.MoTa = "SDSADSAD";
                a.Add(b);
            }
            return View(a);
        }
    }
}
