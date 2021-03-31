using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class Constants
    {
        //Basic
        public const string ViewData = "xem-du-lieu";
        public const string AddData = "tao-du-lieu";
        public const string CreateForm = "tao-form";
        public const string CreateChildForm = "tao-form-phu";

        //URL Route for BCKNBaoCaoSanXuatGiaiDoanController
        public const string BCKNBaoCaoSanXuatGiaiDoan = "bckn-bao-cao-san-xuat-giai-doan";

        //URL Route for BCKNBaoCaoSanXuatTheoNgayController
        public const string BCKNBaoCaoSanXuatTheoNgay = "bckn-bao-cao-san-xuat-theo-ngay";

        //URL Route for BCKNKetQuaPhanTichGiaiDoanController
        public const string BCKNKetQuaPhanTichGiaiDoan = "bckn-ket-qua-phan-tich-giai-doan";

        //URL Route for BCKNKetQuaPhanTichHangNgayController
        public const string BCKNKetQuaPhanTichHangNgay = "bckn-ket-qua-phan-tich-hang-ngay";

        //URL Route for BCSXTTDDienTieuThuController
        public const string BCSXTTDDienTieuThu = "bcsx-ttd-dien-tieu-thu";

        //URL Route for BCSXTTDDienTuPhatController
        public const string BCSXTTDDienTuPhat = "bcsx-ttd-dien-tu-phat";

        //URL Route for BCSXTTDBaoCaoSXTieuThuDienController
        public const string BCSXTTDBaoCaoSXTieuThuDien = "bcsx-ttd-bao-cao-sx-tieu-thu-dien";

        //URL Route for BCSXTTXHSanLuongXeHoiSanXuatController
        public const string BCSXTTXHSanLuongXeHoiSanXuat = "bcsx-tth-san-luong-xe-hoi-san-xuat";

        //URL Route for TDTTChiDaoSanXuatController
        public const string TDTTChiDaoSanXuat = "tdtt-chi-dao-san-xuat";

        //URL Route for TDTTCacPhongBanController
        public const string TDTTCacPhongBan = "tdtt-cac-phong-ban";

        //URL Route for TDThongTinNhanhController
        public const string TDThongTinNhanh = "td-thong-tin-nhanh";

        //URL Route for TDBaoCaoHoaChatVatTuController
        public const string TDBaoCaoHoaChatVatTu = "td-hoa-chat-vat-tu";

        //URL Route for TDGhiNhanSuCoController
        public const string TDGhiNhanSuCo = "td-ghi-nhan-su-co";

        //URL Route for TDSoGiaoCaSanXuatController
        public const string TDSoGiaoCaSanXuat = "td-so-giao-ca-san-xuat";

        //URL Route for TDSanPhamMoiController
        public const string TDSanPhamMoi = "td-san-pham-moi";

        //URL Route for NSLDuongThoController
        public const string NSLDuongTho = "nsl-dt-duong-tho";

        //URL Route for NSLDTKiemTraCanController
        public const string NSLDTKiemTraCan = "nsl-dt-kiem-tra-can";

        //URL Route for NSLBCPCauHinhTheTichBCPController
        public const string NSLBCPCauHinhTheTichBCP = "nsl-bcp-cau-hinh-the-tich-bcp";

        //URL Route for NSLBCPLuongTonBCPController
        public const string NSLBCPLuongTonBCP = "nsl-bcp-luong-ton-bcp";

        //URL Route for NSLBCPKetQuaPhanTichBCPController
        public const string NSLBCPKetQuaPhanTichBCP = "nsl-bcp-ket-qua-phan-tich-bcp";

        //URL Route for NSLDSXDuongThanhPhamQuaCanController
        public const string NSLDSXDuongThanhPhamQuaCan = "nsl-dsx-duong-thanh-pham-qua-can";

        //URL Route for NSLDSXDuongCucBuiQuaCanController
        public const string NSLDSXDuongCucBuiQuaCan = "nsl-dsx-duong-cuc-bui-qua-can";

        //URL Route for NSLDSXDuongKhongPhuHopController
        public const string NSLDSXDuongKhongPhuHop = "nsl-dsx-duong-khong-phu-hop";

        //URL Route for NSLDDBDuongThanhPhamDongBaoController
        public const string NSLDDBDuongThanhPhamDongBao = "nsl-ddb-duong-thanh-pham-dong-bao";

        //URL Route for NSLDDBDuongThanhPhamBoSungController
        public const string NSLDDBDuongThanhPhamBoSung = "nsl-ddb-duong-thanh-pham-bo-sung";

        //URL Route for NSLDDBDuongThanhPhamDuongLongController
        public const string NSLDDBDuongThanhPhamDuongLong = "nsl-ddb-duong-long";

        //URL Route for NSLDDBCanDongBaoController
        public const string NSLDDBCanDongBao = "nsl-ddb-can-dong-bao";

        //URL Route for NSLVatTuHoaChatController
        public const string NSLVatTuHoaChat = "nsl-vat-tu-hoa-chat";

        //URL Route for NSLDuLieuSXTieuThuDienController
        public const string NSLDuLieuSXTieuThuDien = "nsl-du-lieu-sx-tieu-thu-dien";

        //URL Route for NSLDuLieuSXTieuThuHoiController
        public const string NSLDuLieuSXTieuThuHoi = "nsl-du-lieu-sx-tieu-thu-hoi";

        //URL Route for NSLSanPhamMoiController
        public const string NSLSanPhamMoi = "nsl-san-pham-moi";

        //URL Route for NSLPKNNSLBCNhapLieuMuaVuTruocController
        public const string NSLPKNNSLBCNhapLieuMuaVuTruoc = "nsl-pkn-nslbc-nhap-lieu-mua-vu-truoc";

        //URL Route for NSLPKNNSLBCNhapSoLieuBaoCaoNgayController
        public const string NSLPKNNSLBCNhapSoLieuBaoCaoNgay = "nsl-pkn-nslbc-nhap-so-lieu-bao-cao-ngay";

        //URL Route for NSLPKNNSLPTDuongThoController
        public const string NSLPKNNSLPTDuongTho = "nsl-pkn-nslpt-duong-tho";

        //URL Route for NSLPKNNSLPTLamAffController
        public const string NSLPKNNSLPTLamAff = "nsl-pkn-nslpt-lam-aff";

        //URL Route for NSLPKNNSLPTHoaCheLuyenController
        public const string NSLPKNNSLPTHoaCheLuyen = "nsl-pkn-nslpt-hoa-che-luyen";

        //URL Route for NSLPKNNSLPTDuongNonLuyenController
        public const string NSLPKNNSLPTDuongNonLuyen = "nsl-pkn-nslpt-duong-non-luyen";

        //URL Route for NSLPKNNSLPTDuongSauSayController
        public const string NSLPKNNSLPTDuongSauSay = "nsl-pkn-nslpt-duong-sau-say";

        //URL Route for NSLPKNNSLPTDuongThanhPhamController
        public const string NSLPKNNSLPTDuongThanhPham = "nsl-pkn-nslpt-duong-thanh-pham";

        //URL Route for NSLPKNNSLPTDuongKinhDoanhXaSiloController
        public const string NSLPKNNSLPTDuongKinhDoanhXaSilo = "nsl-pkn-nslpt-duong-kinh-doanh-xa-silo";

        //URL Route for NSLPKNNSLPTNuocLoController
        public const string NSLPKNNSLPTNuocLo = "nsl-pkn-nslpt-nuoc-lo";

        //URL Route for NSLPKNNSLPTNuocThaiController
        public const string NSLPKNNSLPTNuocThai = "nsl-pkn-nslpt-nuoc-thai";

        //URL Route for NSLPKNNSLPTBCPDauCaController
        public const string NSLPKNNSLPTBCPDauCa = "nsl-pkn-nslpt-bcp-dau-ca";

        //URL Route for NSLPKNNSLPTDuongThoNhapKhoController
        public const string NSLPKNNSLPTDuongThoNhapKho = "nsl-pkn-nslpt-duong-tho-nhap-kho";

        //URL Route for NSLThucHienMucTieuThangController
        public const string NSLThucHienMucTieuThang = "nsl-thuc-hien-muc-tieu-thang";

        //URL Route for NSLThucHienMucTieuVuController
        public const string NSLThucHienMucTieuVu = "nsl-thuc-hien-muc-tieu-vu";

        //URL Route for NSLDinhMucHCVTController
        public const string NSLDinhMucHCVT = "nsl-dinh-muc-hcvt";

        //URL Route for NSLMucTieuTrongBaoCaoNgayController
        public const string NSLMucTieuTrongBaoCaoNgay = "nsl-muc-tieu-trong-bao-cao-ngay";

        //URL Route for QTHTCongTyThanhVienController
        public const string QTHTCongTyThanhVien = "qtht-cong-ty-thanh-vien";

        //URL Route for QTHTDanhMucChucNangController
        public const string QTHTDanhMucChucNang = "qtht-danh-muc-chuc-nang";

        //URL Route for QTHTCauHinhChucNangController
        public const string QTHTCauHinhChucNang = "qtht-cau-hinh-chuc-nang";

        //URL Route for QTHTCauHinhBaoCaoController
        public const string QTHTCauHinhBaoCao = "qtht-cau-hinh-bao-cao";

        //URL Route for QTHTCauHinhMuaVuController
        public const string QTHTCauHinhMuaVu = "qtht-cau-hinh-mua-vu";

        //URL Route for QTHTCauHinhKyController
        public const string QTHTCauHinhKy = "qtht-cau-hinh-ky";

        //URL Route for QTHTCauHinhCaController
        public const string QTHTCauHinhCa = "qtht-cau-hinh-ca";
    }
}
