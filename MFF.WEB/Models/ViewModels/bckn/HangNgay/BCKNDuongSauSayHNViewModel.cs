using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class BCKNDuongSauSayHNViewModel
    {
        [DisplayName("Mã nồi")]
        public string MaNoi { get; set; }
        [DisplayName("Ca Sx")]
        public string CaSx { get; set; }

        [DisplayName("Pol")]
        public double Pol { get; set; }
        [DisplayName("Độ ẩm")]
        public double DoAm { get; set; }
        [DisplayName("Độ màu")]
        public double DoMau { get; set; }
        [DisplayName("RS")]
        public double RS { get; set; }
        [DisplayName("RS2")]
        public double RS2 { get; set; }
        [DisplayName("Hạt đen")]
        public int HatDen { get; set; }
        [DisplayName("Hạt vàng")]
        public int HatVang { get; set; }
    }
}
