using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class BCKNLamAffGDViewModel
    {
        [DisplayName("Ngày")]
        public string Ngay { get; set; }
        [DisplayName("Ca Sx")]
        public string CaSx { get; set; }
        [DisplayName("Mã số ca")]
        public string MasoCa { get; set; }

        [DisplayName("Bx")]
        public double BxMagma { get; set; }

        //Đường AFF
        [DisplayName("Bx")]
        public double BxDuong { get; set; }
        [DisplayName("Pol")]
        public double PolDuong { get; set; }
        [DisplayName("AP")]
        public double APDuong { get; set; }
        [DisplayName("Màu")]
        public double MauDuong { get; set; }

        //Mật AFF
        [DisplayName("Bx")]
        public double BxMat { get; set; }
        [DisplayName("Pol")]
        public double PolMat { get; set; }
        [DisplayName("AP")]
        public double APMat { get; set; }
    }
}
