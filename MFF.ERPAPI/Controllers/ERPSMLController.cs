using MFF.DTO.Entities.SmartLab;
using MFF.DTO.Helpers;
using MFF.ERPAPI.Services;
using MFF.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MFF.ERPAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class ERPSMLController : ControllerBase
    {
        public readonly ILSXService _service;
        public readonly ITTTieuHaoService _ttsvservice;
        public ERPSMLController(ILSXService service, ITTTieuHaoService ttsvservice)
        {
            _service = service;
            _ttsvservice = ttsvservice;
        }
        [HttpGet("test")]
        public string Get()
        {
            return "Connected";
        }
        // POST api/<ERPSMLController>
        [HttpPost("import-lenh-san-xuat-from-erp")]
        [ProducesResponseType(typeof(SuccessResponseModel<LenhSanXuatERP>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ImporLSXtERPtoSmartlab([FromBody] List<LenhSanXuatERP> items)
        {
            var rs = await _service.AddAsync(items);
            if (rs > 0)
            {
                return ResponseHelper.Success();
            }
            else
            {
                return ResponseHelper.BadRequest("Cập nhật lỗi");
            }
        }

        [HttpPost("import-thong-tin-tieu-hao-from-erp")]
        [ProducesResponseType(typeof(SuccessResponseModel<ThongTinTieuHao>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ImporTTTieuHaotERPtoSmartlab([FromBody] List<ThongTinTieuHao> items)
        {
            var rs = await _ttsvservice.AddAsync(items);
            if (rs > 0)
            {
                return ResponseHelper.Success();
            }
            else
            {
                return ResponseHelper.BadRequest("Cập nhật lỗi");
            }
        }
    }
}
