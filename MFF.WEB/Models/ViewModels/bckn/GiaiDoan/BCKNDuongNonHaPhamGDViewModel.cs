using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class BCKNDuongNonHaPhamGDViewModel
    {
        [DisplayName("Ngày")]
        public string Ngay { get; set; }
        [DisplayName("Ca Sx")]
        public string CaSx { get; set; }
        [DisplayName("Mã số ca")]
        public string MaSoCa { get; set; }

        //Đường non R4
        [DisplayName("Số nồi")]
        public int SoNoiR4 { get; set; }
        [DisplayName("V")]
        public double VR4 { get; set; }
        [DisplayName("t")]
        public double tR4 { get; set; }
        [DisplayName("Bx")]
        public double BxR4 { get; set; }
        [DisplayName("AP")]
        public double APR4 { get; set; }
        [DisplayName("RS")]
        public double RSR4 { get; set; }
        //Mật R4
        [DisplayName("Bx")]
        public double BxMR4 { get; set; }
        [DisplayName("AP")]
        public double APMR4 { get; set; }
        [DisplayName("RS")]
        public double RSMR4 { get; set; }
        [DisplayName("pH")]
        public double pHMR4 { get; set; }
        //Mật R4 - có acetat
        [DisplayName("Bx")]
        public double BxMR4ACE { get; set; }
        [DisplayName("AP")]
        public double APMR4ACE { get; set; }
        //Hồi dung R4
        [DisplayName("Bx")]
        public int BxR4HoiDung { get; set; }
        [DisplayName("AP")]
        public double APR4HoiDung { get; set; }
        [DisplayName("RS")]
        public double RSR4HoiDung { get; set; }
        [DisplayName("Màu")]
        public double MauR4HoiDung { get; set; }

        //Đường non R5
        [DisplayName("Số nồi")]
        public int SoNoiR5 { get; set; }
        [DisplayName("V")]
        public double VR5 { get; set; }
        [DisplayName("t")]
        public double tR5 { get; set; }
        [DisplayName("Bx")]
        public double BxR5 { get; set; }
        [DisplayName("AP")]
        public double APR5 { get; set; }
        [DisplayName("RS")]
        public double RSR5 { get; set; }
        //Mật R5
        [DisplayName("Bx")]
        public double BxMR5 { get; set; }
        [DisplayName("AP")]
        public double APMR5 { get; set; }
        [DisplayName("RS")]
        public double RSMR5 { get; set; }
        [DisplayName("pH")]
        public double pHMR5 { get; set; }
        //Hồi dung R5
        [DisplayName("Bx")]
        public int BxR5HoiDung { get; set; }
        [DisplayName("AP")]
        public double APR5HoiDung { get; set; }
        [DisplayName("RS")]
        public double RSR5HoiDung { get; set; }
        [DisplayName("Màu")]
        public double MauR5HoiDung { get; set; }
        //Hồi dung R5 - có acetat
        [DisplayName("Bx")]
        public int BxR5HoiDungACE { get; set; }
        [DisplayName("AP")]
        public double APR5HoiDungACE { get; set; }

        //Đường non R6
        [DisplayName("Số nồi")]
        public int SoNoiR6 { get; set; }
        [DisplayName("V")]
        public double VR6 { get; set; }
        [DisplayName("t")]
        public double tR6 { get; set; }
        [DisplayName("Bx")]
        public double BxR6 { get; set; }
        [DisplayName("AP")]
        public double APR6 { get; set; }
        [DisplayName("RS")]
        public double RSR6 { get; set; }
        //Mật R6
        [DisplayName("Bx")]
        public double BxMR6 { get; set; }
        [DisplayName("AP")]
        public double APMR6 { get; set; }
        [DisplayName("RS")]
        public double RSMR6 { get; set; }
        [DisplayName("pH")]
        public double pHMR6 { get; set; }
        //Hồi dung R6
        [DisplayName("Bx")]
        public int BxR6HoiDung { get; set; }
        [DisplayName("AP")]
        public double APR6HoiDung { get; set; }
        [DisplayName("RS")]
        public double RSR6HoiDung { get; set; }

        //Đường non R7
        [DisplayName("Số nồi")]
        public int SoNoiR7 { get; set; }
        [DisplayName("V")]
        public double VR7 { get; set; }
        [DisplayName("t")]
        public double tR7 { get; set; }
        [DisplayName("Bx")]
        public double BxR7 { get; set; }
        [DisplayName("AP")]
        public double APR7 { get; set; }
        [DisplayName("RS")]
        public double RSR7 { get; set; }
        //Mật R4
        [DisplayName("Bx")]
        public double BxMR7 { get; set; }
        [DisplayName("AP")]
        public double APMR7 { get; set; }
        [DisplayName("RS")]
        public double RSMR7 { get; set; }
        [DisplayName("pH")]
        public double pHMR7 { get; set; }
        //Hồi dung R7
        [DisplayName("Bx")]
        public int BxR7HoiDung { get; set; }
        [DisplayName("AP")]
        public double APR7HoiDung { get; set; }
        [DisplayName("RS")]
        public double RSR7HoiDung { get; set; }

        //Mật rỉ
        [DisplayName("Mật rỉ")]
        public double BxMatRi { get; set; }
    }
}
