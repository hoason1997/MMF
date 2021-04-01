using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class BCKNDuongThoNhapKhoHNViewModel
    {
        [DisplayName("Đường thô nguyên liệu")]
        public string DuongThoNguyenLieu { get; set; }
        [DisplayName("Tên lô")]
        public string TenLo { get; set; }
        [DisplayName("Giờ")]
        public string Gio { get; set; }
        [DisplayName("Ca Sx")]
        public string CaSx { get; set; }

        [DisplayName("Pol")]
        public double Pol { get; set; }
        [DisplayName("Độ ẩm")]
        public double DoAm { get; set; }
        [DisplayName("Màu")]
        public double Mau { get; set; }
        [DisplayName("Tro dẫn điện")]
        public double Tro { get; set; }
        [DisplayName("RS1")]
        public double RS1 { get; set; }
        [DisplayName("RS2")]
        public double RS2 { get; set; }
        [DisplayName("TKCT")]
        public double TKCT { get; set; }
        [DisplayName("Tinh bột (mg/kg)")]
        public double TinhBot { get; set; }
        [DisplayName("Dextran (mg/kg)")]
        public double Dextran { get; set; }
        [DisplayName("SO2 (mg/kg)")]
        public double SO2 { get; set; }
    }
}
