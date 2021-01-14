using MFF.ERPAPI.Database;
using MFF.ERPAPI.Entities;
using MFF.ERPAPI.Factories;
using MFF.ERPAPI.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MFF.ERPAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class ERPSMLController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWorkTA;
        private readonly IUnitOfWork _unitOfWorkTTC;
        public ERPSMLController(IUnitOfWork<BHSTADBContext> unitOfWork, IUnitOfWork<TTCSDBContext> unitOfWorkTTC)
        {
            _unitOfWorkTA = unitOfWork;
            _unitOfWorkTTC = unitOfWorkTTC;
        }
        [HttpGet("test")]
        public string Get()
        {
            return "Connected";
        }
        // POST api/<ERPSMLController>
        [HttpPost("import-lenh-san-xuat-from-erp")]
        public async Task<int> ImporLSXtERPtoSmartlab([FromBody] List<LenhSanXuatERP> items)
        {
            try
            {
                var ta = _unitOfWorkTA.GetRepository<LenhSanXuatERP>();
                var ttc = _unitOfWorkTTC.GetRepository<LenhSanXuatERP>();
                foreach (var item in items)
                {
                    switch (item.BUSINESS_UNIT_NAME)
                    {
                        case TextContant.Orther:
                            ta.UpdateOrInSert(item, x => x.WORK_ORDER_ID == item.WORK_ORDER_ID);
                            break;
                        case TextContant.TTCS:
                            ttc.UpdateOrInSert(item, x => x.WORK_ORDER_ID == item.WORK_ORDER_ID);
                            break;
                        default:
                            break;
                    }
                }
                await _unitOfWorkTA.SaveChangesAsync();
                await _unitOfWorkTTC.SaveChangesAsync();
                return 1;
            }
            catch (System.Exception ex)
            {
                return 0;
            }
        }

        [HttpPost("import-thong-tin-tieu-hao-from-erp")]
        public async Task<int> ImporTTTieuHaotERPtoSmartlab([FromBody] List<ThongTinTieuHao> items)
        {
            try
            {
                var ta = _unitOfWorkTA.GetRepository<ThongTinTieuHao>();
                var ttc = _unitOfWorkTTC.GetRepository<ThongTinTieuHao>();
                foreach (var item in items)
                {
                    switch (item.BUSINESS_UNIT_NAME)
                    {
                        case TextContant.Orther:
                            ta.UpdateOrInSert(item, x => x.TRANSACTION_ID == item.TRANSACTION_ID);
                            break;
                        case TextContant.TTCS:
                            ttc.UpdateOrInSert(item, x => x.TRANSACTION_ID == item.TRANSACTION_ID);
                            break;
                        default:
                            break;
                    }
                }
                await _unitOfWorkTA.SaveChangesAsync();
                await _unitOfWorkTTC.SaveChangesAsync();
                return 1;
            }
            catch (System.Exception ex)
            {
                return 0;
            }
        }
    }
}
