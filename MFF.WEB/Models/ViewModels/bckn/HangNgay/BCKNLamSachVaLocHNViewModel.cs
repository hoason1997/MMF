using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class BCKNLamSachVaLocHNViewModel
    {
        [DisplayName("Giờ")]
        public string Gio { get; set; }
        [DisplayName("Ca Sx")]
        public string CaSx { get; set; }

        //Nước đường nguyên
        [DisplayName("pH")]
        public double pHDuongNguyen { get; set; }
        [DisplayName("Bx")]
        public double BxDuongNguyen { get; set; }
        [DisplayName("AP")]
        public double APDuongNguyen { get; set; }
        [DisplayName("Màu2")]
        public double Mau2DuongNguyen { get; set; }
        [DisplayName("RS")]
        public double RSDuongNguyen { get; set; }
        [DisplayName("SO2")]
        public double SO2DuongNguyen { get; set; }

        //Nước gia vôi
        [DisplayName("pH")]
        public double pHGiaVoi { get; set; }
        [DisplayName("Bx")]
        public double BxGiavoi { get; set; }
        [DisplayName("C (Be)")]
        public double CBEGiaVoi { get; set; }

        //Nước đường Cacbonat
        [DisplayName("T1")]
        public double T1Cacbonat { get; set; }
        [DisplayName("pH1")]
        public double pH1Cacbonat { get; set; }
        [DisplayName("pH2")]
        public double pH2Cacbonat { get; set; }
        [DisplayName("T3")]
        public double T3Cacbonat { get; set; }
        [DisplayName("pH3")]
        public double pH3Cacbonat { get; set; }
        [DisplayName("pH4")]
        public double pH4Cacbonat { get; set; }

        //Lọc 1
        [DisplayName("t")]
        public double tL1 { get; set; }
        [DisplayName("pH")]
        public double pHL1 { get; set; }
        [DisplayName("Bx")]
        public double BxL1 { get; set; }
        [DisplayName("AP")]
        public double APL1 { get; set; }
        [DisplayName("Màu 2")]
        public double Mau2L1 { get; set; }
        [DisplayName("RS")]
        public double RSL1 { get; set; }
        [DisplayName("SO2")]
        public double SO2L1 { get; set; }

        //Lọc 2
        [DisplayName("t")]
        public double tL2 { get; set; }
        [DisplayName("pH")]
        public double pHL2 { get; set; }
        [DisplayName("Bx")]
        public double BxL2 { get; set; }
        [DisplayName("AP")]
        public double APL2 { get; set; }
        [DisplayName("Màu 2")]
        public double Mau2L2 { get; set; }
        [DisplayName("RS")]
        public double RSL2 { get; set; }

        //Bã bùn
        [DisplayName("Pol")]
        public double PolBaBun { get; set; }
        [DisplayName("Ẩm")]
        public double AmBaBun { get; set; }
    }
}
