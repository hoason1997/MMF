using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class BCKNDuongThoGDViewModel
    {
        [DisplayName("Đường thô nguyên liệu")]
        public string DuongThoNguyenLieu { get; set; }
        [DisplayName("Ngày")]
        public string Ngay { get; set; }
        [DisplayName("Ca Sx")]
        public string CaSx { get; set; }
        [DisplayName("Pol")]
        public double Pol { get; set; }
        [DisplayName("Độ ẩm")]
        public double DoAm { get; set; }
        [DisplayName("Màu 2")]
        public double Mau2 { get; set; }
        [DisplayName("Tro Sulfat")]
        public double TroSulfat { get; set; }
        [DisplayName("Tro dẫn điện")]
        public double TroDanDien { get; set; }
        [DisplayName("RS1")]
        public double RS1 { get; set; }
        [DisplayName("RS2")]
        public double RS2 { get; set; }
        [DisplayName("TCKT")]
        public string TCKT { get; set; }
        [DisplayName("Tinh bột (mg/kg")]
        public double TinhBot { get; set; }
        [DisplayName("Dextran (mg/kg)")]
        public double Dextran { get; set; }
    }
}
