using MFF.Data.SmartLab;
using MFF.DTO.Entities.SmartLab;
using MFF.ERPAPI.Factories;
using MFF.ERPAPI.Helper;
using MFF.ERPAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly IUnitOfWork _unitOfWorkTN;
        private readonly IUnitOfWork _unitOfWorkBHS;
        private readonly IUnitOfWork _unitOfWorkPRS;
        private readonly IUnitOfWork _unitOfWorkSEC;
        private readonly IUnitOfWork _unitOfWorkTTCS;
        private readonly IUnitOfWork _unitOfWorkHAA;
        private readonly IUnitOfWork _unitOfWorkNHS;

        public ERPSMLController(IUnitOfWork<BHSTADBContext> unitOfWorkTA, IUnitOfWork<TTCDBContext> unitOfWorkTTCS, IUnitOfWork<BHSDNDBContext> unitOfWorkTN, IUnitOfWork<NHSDBContext> unitOfWorkNHS, IUnitOfWork<SECDBContext> unitOfWorkSEC, IUnitOfWork<PHANRANGDBContext> unitOfWorkPRS, IUnitOfWork<BHSDNDBContext> unitOfWorkBHS, IUnitOfWork<BHSDNDBContext> unitOfWorkHAA)
        {
            _unitOfWorkTA = unitOfWorkTA;
            _unitOfWorkTN = unitOfWorkTN;
            _unitOfWorkBHS = unitOfWorkBHS;
            _unitOfWorkPRS = unitOfWorkPRS;

            _unitOfWorkNHS = unitOfWorkNHS;
            _unitOfWorkSEC = unitOfWorkSEC;
            _unitOfWorkTTCS = unitOfWorkTTCS;
            _unitOfWorkHAA = unitOfWorkHAA;


        }
        [HttpGet("test")]
        public string Get()
        {
            return "Connected";
        }

        [HttpPost("test-post")]
        public async Task<int> POSTDATA([FromBody] ResponseModel items)
        {

            return 12;
        }
        // POST api/<ERPSMLController>
        [HttpPost("import-lenh-san-xuat-from-erp")]
        public async Task<int> ImporLSXtERPtoSmartlab([FromBody] List<LenhSanXuatImport> items)
        {
            try
            {
                var ta = _unitOfWorkTA.GetRepository<LenhSanXuatImport>();
                var ttc = _unitOfWorkTTCS.GetRepository<LenhSanXuatImport>();
                var bhsdn = _unitOfWorkBHS.GetRepository<LenhSanXuatImport>();
                var tn = _unitOfWorkTN.GetRepository<LenhSanXuatImport>();
                var nhs = _unitOfWorkNHS.GetRepository<LenhSanXuatImport>();
                var prs = _unitOfWorkPRS.GetRepository<LenhSanXuatImport>();
                var sec = _unitOfWorkSEC.GetRepository<LenhSanXuatImport>();
                var haa = _unitOfWorkHAA.GetRepository<LenhSanXuatImport>();

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
                        case TextContant.BHSDN:
                            bhsdn.UpdateOrInSert(item, x => x.WORK_ORDER_ID == item.WORK_ORDER_ID);
                            break;
                        case TextContant.BHSTN:
                            tn.UpdateOrInSert(item, x => x.WORK_ORDER_ID == item.WORK_ORDER_ID);
                            break;
                        case TextContant.NHS:
                            nhs.UpdateOrInSert(item, x => x.WORK_ORDER_ID == item.WORK_ORDER_ID);
                            break;
                        case TextContant.PHANRANG:
                            prs.UpdateOrInSert(item, x => x.WORK_ORDER_ID == item.WORK_ORDER_ID);
                            break;
                        case TextContant.SEC:
                            sec.UpdateOrInSert(item, x => x.WORK_ORDER_ID == item.WORK_ORDER_ID);
                            break;
                        case TextContant.HAA:
                            haa.UpdateOrInSert(item, x => x.WORK_ORDER_ID == item.WORK_ORDER_ID);
                            break;
                        case TextContant.BHSTA:
                            ta.UpdateOrInSert(item, x => x.WORK_ORDER_ID == item.WORK_ORDER_ID);
                            break;
                        default:
                            break;
                    }
                }

                await _unitOfWorkTA.SaveChangesAsync();
                await _unitOfWorkTTCS.SaveChangesAsync();
                await _unitOfWorkBHS.SaveChangesAsync();
                await _unitOfWorkTN.SaveChangesAsync();
                await _unitOfWorkNHS.SaveChangesAsync();
                await _unitOfWorkPRS.SaveChangesAsync();
                await _unitOfWorkSEC.SaveChangesAsync();
                await _unitOfWorkHAA.SaveChangesAsync();

                return 1;
            }
            catch (System.Exception ex)
            {
                return 0;
            }
        }

        [HttpPost("import-thong-tin-tieu-hao-from-erp")]
        public async Task<int> ImporTTTieuHaotERPtoSmartlab([FromBody] List<ThongTinTieuHaoImport> items)
        {
            try
            {
                var ta = _unitOfWorkTA.GetRepository<ThongTinTieuHaoImport>();
                var ttc = _unitOfWorkTTCS.GetRepository<ThongTinTieuHaoImport>();
                var bhsdn = _unitOfWorkBHS.GetRepository<ThongTinTieuHaoImport>();
                var tn = _unitOfWorkTN.GetRepository<ThongTinTieuHaoImport>();

                var nhs = _unitOfWorkNHS.GetRepository<ThongTinTieuHaoImport>();
                var prs = _unitOfWorkPRS.GetRepository<ThongTinTieuHaoImport>();
                var sec = _unitOfWorkSEC.GetRepository<ThongTinTieuHaoImport>();
                var haa = _unitOfWorkHAA.GetRepository<ThongTinTieuHaoImport>();

                foreach (var item in items)
                {
                    var typeRW = item.WO_SUB_TYPE + string.Empty;
                    var flag = item.REWORK_FLAG + string.Empty;
                    var bom = item.BOM_FLAG + string.Empty;
                    if (typeRW.ToLower() != "rework" || (flag.ToLower() != "y" && bom.ToLower() != "n"))
                    {
                        switch (item.BUSINESS_UNIT_NAME)
                        {
                            case TextContant.Orther:
                                InsertThreeTable(_unitOfWorkTA, item);
                                break;
                            case TextContant.TTCS:
                                InsertThreeTable(_unitOfWorkTTCS, item);
                                break;
                            case TextContant.BHSDN:
                                InsertThreeTable(_unitOfWorkBHS, item);
                                break;
                            case TextContant.BHSTN:
                                InsertThreeTable(_unitOfWorkTN, item);
                                break;
                            case TextContant.NHS:
                                InsertThreeTable(_unitOfWorkNHS, item);
                                break;
                            case TextContant.PHANRANG:
                                InsertThreeTable(_unitOfWorkPRS, item);
                                break;
                            case TextContant.SEC:
                                InsertThreeTable(_unitOfWorkSEC, item);
                                break;
                            case TextContant.BHSTA:
                                InsertThreeTable(_unitOfWorkTA, item);
                                break;
                            case TextContant.HAA:
                                InsertThreeTable(_unitOfWorkHAA, item);
                                break;
                            default:
                                break;
                        }
                    }
                }
                await _unitOfWorkTA.SaveChangesAsync();
                await _unitOfWorkTTCS.SaveChangesAsync();
                await _unitOfWorkBHS.SaveChangesAsync();
                await _unitOfWorkTN.SaveChangesAsync();

                await _unitOfWorkNHS.SaveChangesAsync();
                await _unitOfWorkPRS.SaveChangesAsync();
                await _unitOfWorkSEC.SaveChangesAsync();
                await _unitOfWorkHAA.SaveChangesAsync();
                return 1;
            }
            catch (System.Exception ex)
            {
                return 0;
            }
        }

        private void InsertThreeTable(IUnitOfWork uniofWork, ThongTinTieuHaoImport item)
        {
            switch (item.CATEGORY + string.Empty)
            {
                case DANHMUC.TP:
                    DuongNhapKhoUpSert(uniofWork, item);
                    break;
                case DANHMUC.BTP:
                    PhanTichDuongThoNhapKhoUpSert(uniofWork, item);
                    break;
                default:
                    HoaChatUpSert(uniofWork, item);
                    break;
            }
        }

        private void PhanTichDuongThoNhapKhoUpSert(IUnitOfWork uniofWork, ThongTinTieuHaoImport item)
        {
            var itemFirst = uniofWork.GetRepository<CauHinhBang>().GetFirstOrDefault(x => x, x => x.MaERP == item.ITEM_NUMBER || x.TenDong == item.ITEM_NAME);
            if (itemFirst != null)
            {
                var CTTVBang = uniofWork.GetRepository<CttvThuocBang>().GetFirstOrDefault(x => x, x => x.Ma_CauHinhBang == itemFirst.Ma_CauHinhBang);

                if (CTTVBang != null)
                {
                    var rs = uniofWork.GetRepository<PhanTichDuongThoNhapKho>().GetFirstOrDefault(x => x, x => x.Ma_CttvThuocBang == CTTVBang.Ma_CttvThuocBang && x.NgayTao == item.TRANSACTION_DATE.Date);
                    if (rs == null)
                    {
                        uniofWork.GetRepository<PhanTichDuongThoNhapKho>().Insert(new PhanTichDuongThoNhapKho
                        {
                            GiaTri = item.TRANSACTION_QTY,
                            Ma_CttvThuocBang = CTTVBang.Ma_CttvThuocBang,
                            NgayTao = item.TRANSACTION_DATE,
                            TaoBoi = ""
                        });
                        uniofWork.GetRepository<ThongTinTieuHaoImport>().Insert(item);
                    }
                    else
                    {
                        rs.GiaTri = item.TRANSACTION_QTY;
                        rs.NgayTao = item.TRANSACTION_DATE;

                        uniofWork.GetRepository<PhanTichDuongThoNhapKho>().Update(rs);
                    }
                }
            }
        }
        private void DuongNhapKhoUpSert(IUnitOfWork uniofWork, ThongTinTieuHaoImport item)
        {
            var itemFirst = uniofWork.GetRepository<CauHinhBang>().GetFirstOrDefault(x => x, x => x.MaERP == item.ITEM_NUMBER || x.TenDong == item.ITEM_NAME);
            if (itemFirst != null)
            {
                var CTTVBang = uniofWork.GetRepository<CttvThuocBang>().GetFirstOrDefault(x => x, x => x.Ma_CauHinhBang == itemFirst.Ma_CauHinhBang);

                if (CTTVBang != null)
                {
                    var rs = uniofWork.GetRepository<DuongNhapKho>().GetFirstOrDefault(x => x, x => x.Ma_CttvThuocBang == CTTVBang.Ma_CttvThuocBang && x.Ngay == item.TRANSACTION_DATE.Date);
                    if (rs == null)
                    {
                        uniofWork.GetRepository<DuongNhapKho>().Insert(new DuongNhapKho
                        {
                            Ngay = item.TRANSACTION_DATE,
                            GiaTri = item.TRANSACTION_QTY,
                            Ma_CttvThuocBang = CTTVBang.Ma_CttvThuocBang,
                            NgayTao = item.TRANSACTION_DATE,
                            TaoBoi = "",
                            Xoa = false,
                        });
                        uniofWork.GetRepository<ThongTinTieuHaoImport>().Insert(item);
                    }
                    else
                    {
                        rs.GiaTri = item.TRANSACTION_QTY;
                        rs.NgayTao = item.TRANSACTION_DATE;
                        uniofWork.GetRepository<DuongNhapKho>().Update(rs);
                    }
                }
            }
        }
        private void HoaChatUpSert(IUnitOfWork uniofWork, ThongTinTieuHaoImport item)
        {
            var itemFirst = uniofWork.GetRepository<CauHinhBang>().GetFirstOrDefault(x => x, x => x.MaERP == item.ITEM_NUMBER || x.TenDong == item.ITEM_NAME);

            CttvThuocBang CTTVBang = null;

            if (itemFirst != null)
            {
                CTTVBang = uniofWork.GetRepository<CttvThuocBang>().GetFirstOrDefault(x => x, x => x.Ma_CauHinhBang == itemFirst.Ma_CauHinhBang);
            }
            else
            {
                var KVTHC = uniofWork.GetRepository<CauHinhBang>().GetFirstOrDefault(x => x, x => x.Ma_Bang == "KVT");
                if (KVTHC != null)
                {
                    /// Insert CauHinhBang
                    var newCauHinhBang = uniofWork.GetRepository<CauHinhBang>().Insert(new CauHinhBang
                    {
                        TenDong = item.ITEM_NAME,
                        MaERP = item.ITEM_NAME,
                        Xoa = false,
                        CapDo = 2,
                        CauHinhBang_Cha = KVTHC.Ma_CauHinhBang,
                        NgayTao = DateTime.Now,
                        NgayCapNhat = DateTime.Now,
                        TaoBoi = "ERP"
                    });
                    uniofWork.SaveChanges();
                    /// Insert CttvThuocBang
                    var newCttvBang = uniofWork.GetRepository<CttvThuocBang>().Insert(new CttvThuocBang
                    {

                        Ma_Cttv = 0,
                        CauHinhBang_Cha = KVTHC.Ma_CauHinhBang,
                        Ma_CauHinhBang = newCauHinhBang.Ma_CauHinhBang,
                        Xoa = false,
                        NgayTao = DateTime.Now,
                        NgayCapNhat = DateTime.Now,
                        TaoBoi = "ERP"
                    });
                    uniofWork.SaveChanges();
                    CTTVBang = uniofWork.GetRepository<CttvThuocBang>().GetFirstOrDefault(x => x, x => x.Ma_CauHinhBang == newCttvBang.Ma_CauHinhBang);
                }
                /// else  trương hợp ko có kho vật tư
            }
            UpdateHoaVatTu(uniofWork, item, CTTVBang);
        }

        private static void UpdateHoaVatTu(IUnitOfWork uniofWork, ThongTinTieuHaoImport item, CttvThuocBang CTTVBang)
        {
            if (CTTVBang != null)
            {
                var rs = uniofWork.GetRepository<HoaChat>().GetFirstOrDefault(x => x, x => x.Ma_CttvThuocBang == CTTVBang.Ma_CttvThuocBang && x.Ngay == item.TRANSACTION_DATE.Date);
                if (rs == null)
                {
                    var rs1 = uniofWork.GetRepository<HoaChat>().Insert(new HoaChat
                    {
                        Ngay = item.TRANSACTION_DATE,
                        GiaTri = item.TRANSACTION_QTY,
                        Ma_CttvThuocBang = CTTVBang.Ma_CttvThuocBang,
                        NgayTao = item.TRANSACTION_DATE,
                        TaoBoi = "",
                        Xoa = false,
                    });
                    uniofWork.GetRepository<ThongTinTieuHaoImport>().Insert(item);
                }
                else
                {
                    rs.GiaTri = item.TRANSACTION_QTY;
                    rs.NgayTao = item.TRANSACTION_DATE;
                    uniofWork.GetRepository<HoaChat>().Update(rs);
                }
            }
        }
    }
}
