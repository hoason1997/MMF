using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class BCKNDuongKinhDoanhXaGDSiloViewModel
    {
        [DisplayName("Đường kinh doanh xá Silo")]
        public string DuongKinhDoanhXaSilo { get; set; }
        [DisplayName("Ngày")]
        public string Ngay { get; set; }
        [DisplayName("Ca Sx")]
        public string CaSx { get; set; }

        [DisplayName("Pol")]
        public double Pol { get; set; }
        [DisplayName("Độ ẩm")]
        public double DoAm { get; set; }
        [DisplayName("Độ màu")]
        public double DoMau { get; set; }
        [DisplayName("Tro")]
        public double Tro { get; set; }
        [DisplayName("RS")]
        public double RS { get; set; }
        [DisplayName("RS2")]
        public double RS2 { get; set; }
        [DisplayName("TKCT")]
        public double TKCT { get; set; }
        [DisplayName("MA")]
        public double MA { get; set; }
        [DisplayName("CV")]
        public int CV { get; set; }
        [DisplayName("Hạt đen")]
        public int HatDen { get; set; }
        [DisplayName("Hạt vàng")]
        public int HatVang { get; set; }
        [DisplayName("SO2")]
        public double SO2 { get; set; }
        [DisplayName("Bụi đen")]
        public int BuiDen { get; set; }
        [DisplayName("Vitamin A")]
        public double VitaminA { get; set; }
    }
}
