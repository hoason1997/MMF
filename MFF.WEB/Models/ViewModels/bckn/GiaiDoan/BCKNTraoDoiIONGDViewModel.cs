using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class BCKNTraoDoiIONGDViewModel
    {
        [DisplayName("Ngày")]
        public string Ngay { get; set; }
        [DisplayName("Ca Sx")]
        public string CaSx { get; set; }
        [DisplayName("Mã số ca")]
        public string MaSoCa { get; set; }

        //Tổng đầu ra Resin
        [DisplayName("Bx")]
        public double BxResin { get; set; }
        [DisplayName("AP")]
        public double APResin { get; set; }
        [DisplayName("RS")]
        public double RSResin { get; set; }

        //Các cột Resin thành phần
        [DisplayName("t1")]
        public double t1ThanhPhan { get; set; }
        [DisplayName("pH1")]
        public double pH1ThanhPhan { get; set; }
        [DisplayName("Bx1")]
        public double Bx1ThanhPhan { get; set; }
        [DisplayName("Màu 1")]
        public double Mau1ThanhPhan { get; set; }
        [DisplayName("t2")]
        public double t2ThanhPhan { get; set; }
        [DisplayName("pH2")]
        public double pH2ThanhPhan { get; set; }
        [DisplayName("Bx2")]
        public double Bx2ThanhPhan { get; set; }
        [DisplayName("Màu 2")]
        public double Mau2ThanhPhan { get; set; }
        [DisplayName("t3")]
        public double t3ThanhPhan { get; set; }
        [DisplayName("pH3")]
        public double pH3ThanhPhan { get; set; }
        [DisplayName("Bx3")]
        public double Bx3ThanhPhan { get; set; }
        [DisplayName("Màu 3")]
        public double Mau3ThanhPhan { get; set; }
        [DisplayName("t4")]
        public double t4ThanhPhan { get; set; }
        [DisplayName("pH4")]
        public double pH4ThanhPhan { get; set; }
        [DisplayName("Bx4")]
        public double Bx4Thanhphan { get; set; }
        [DisplayName("Màu 4")]
        public double Mau4ThanhPhan { get; set; }
        [DisplayName("t5")]
        public double t5ThanhPhan { get; set; }
        [DisplayName("pH5")]
        public double pH5ThanhPhan { get; set; }
        [DisplayName("Bx5")]
        public double Bx5ThanhPhan { get; set; }
        [DisplayName("Màu 5")]
        public double Mau5ThanhPhan { get; set; }

        //Lọc ceramic
        [DisplayName("t")]
        public double tCeramic { get; set; }
        [DisplayName("pHCeramic")]
        public double pHCeramic { get; set; }
        [DisplayName("Bx")]
        public double BxCeramic { get; set; }
        [DisplayName("AP")]
        public double APCeramic { get; set; }
        [DisplayName("RS")]
        public double RSCeramic { get; set; }
        [DisplayName("Màu")]
        public double MauCeramic { get; set; }
        [DisplayName("Tro Sulfat")]
        public double TroSulfatCeramic { get; set; }
        [DisplayName("Tro dẫn điện")]
        public double TroDanDienCeramic { get; set; }
        [DisplayName("TKCT")]
        public double TKCTCeramic { get; set; }

        //Bốc hơi hiệu 1
        [DisplayName("Bx")]
        public double BxHieu1 { get; set; }

        //Bốc hơi hiệu 2
        [DisplayName("Bx")]
        public double BxHieu2 { get; set; }
        [DisplayName("pH")]
        public double pHHieu2 { get; set; }
        [DisplayName("AP")]
        public double APHieu2 { get; set; }
        [DisplayName("Màu TEA")]
        public double MauTEAHieu2 { get; set; }
        [DisplayName("Màu")]
        public double MauHieu2 { get; set; }
        [DisplayName("RS")]
        public double RSHieu2 { get; set; }

        //Đường lỏng cao cấp < 45IU hòa tan
        [DisplayName("pH")]
        public double pHDuongLong { get; set; }
        [DisplayName("Bx")]
        public double BxDuongLong { get; set; }
        [DisplayName("Màu")]
        public double MauDuongLong { get; set; }
        [DisplayName("Độ đục")]
        public double DoDucDuongLong { get; set; }
        [DisplayName("RS")]
        public double RSDuongLong { get; set; }
        [DisplayName("TCKT")]
        public double TCKTDuongLong { get; set; }

        //Tái sinh Resin     
        [DisplayName("Bx")]
        public double BxTSResin { get; set; }
        [DisplayName("NaCL")]
        public double NaCLTSResin { get; set; }
        [DisplayName("pH")]
        public double pHTSResin { get; set; }

        //E.14
        [DisplayName("Bx")]
        public double BxE14 { get; set; }
    }
}
