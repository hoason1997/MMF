using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class BCKNDuongNonCaoPhamGDViewModel
    {
        [DisplayName("Ngày")]
        public string Ngay { get; set; }
        [DisplayName("Ca Sx")]
        public string CaSx { get; set; }
        [DisplayName("Mã số ca")]
        public string MaSoCa { get; set; }

        //Đường non R1
        [DisplayName("Số nồi")]
        public int SoNoiR1 { get; set; }
        [DisplayName("V")]
        public double VR1 { get; set; }
        [DisplayName("t")]
        public double tR1 { get; set; }
        [DisplayName("Bx")]
        public double BxR1 { get; set; }
        [DisplayName("AP")]
        public double APR1 { get; set; }
        [DisplayName("RS")]
        public double RSR1 { get; set; }
        //Mật R1
        [DisplayName("Bx")]
        public double BxMR1 { get; set; }
        [DisplayName("AP")]
        public double APMR1 { get; set; }
        [DisplayName("RS")]
        public double RSMR1 { get; set; }

        //Đường non R2
        [DisplayName("Số nồi")]
        public int SoNoiR2 { get; set; }
        [DisplayName("V")]
        public double VR2 { get; set; }
        [DisplayName("t")]
        public double tR2 { get; set; }
        [DisplayName("Bx")]
        public double BxR2 { get; set; }
        [DisplayName("AP")]
        public double APR2 { get; set; }
        [DisplayName("RS")]
        public double RSR2 { get; set; }
        //Mật R2
        [DisplayName("Bx")]
        public double BxMR2 { get; set; }
        [DisplayName("AP")]
        public double APMR2 { get; set; }
        [DisplayName("RS")]
        public double RSMR2 { get; set; }

        //Đường non R3
        [DisplayName("Số nồi")]
        public int SoNoiR3 { get; set; }
        [DisplayName("V")]
        public double VR3 { get; set; }
        [DisplayName("t")]
        public double tR3 { get; set; }
        [DisplayName("Bx")]
        public double BxR3 { get; set; }
        [DisplayName("AP")]
        public double APR3 { get; set; }
        [DisplayName("RS")]
        public double RSR3 { get; set; }
        //Mật R3
        [DisplayName("Bx")]
        public double BxMR3 { get; set; }
        [DisplayName("AP")]
        public double APMR3 { get; set; }
        [DisplayName("RS")]
        public double RSMR3 { get; set; }
    }
}
