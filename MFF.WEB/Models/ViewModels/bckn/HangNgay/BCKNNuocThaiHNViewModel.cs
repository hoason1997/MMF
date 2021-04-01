using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class BCKNNuocThaiHnViewModel
    {
        [DisplayName("Giờ")]
        public string Gio { get; set; }
        [DisplayName("Ca Sx")]
        public string CaSx { get; set; }

        //Hố gom PXĐ
        [DisplayName("COD")]
        public double CODPXD { get; set; }
        [DisplayName("Bx")]
        public double BxPXD { get; set; }

        //Hố gom bàn lọc
        [DisplayName("COD")]
        public double CODLoc { get; set; }
        [DisplayName("Bx")]
        public double BxLoc { get; set; }

        //Nước bể điều hòa
        [DisplayName("COD")]
        public double CODDieuHoa { get; set; }
        [DisplayName("Bx")]
        public double BxDieuHoa { get; set; }

        //Nước vào tập trung
        [DisplayName("COD")]
        public double CODTapTrung { get; set; }
        [DisplayName("Bx")]
        public double BxTapTrung { get; set; }
        [DisplayName("SS")]
        public double SSTapTrung { get; set; }
        [DisplayName("N Tổng")]
        public double NTongTapTrung { get; set; }
        [DisplayName("P Tổng")]
        public double PTongTapTrung { get; set; }
        [DisplayName("pH")]
        public double pHTapTrung { get; set; }

        //Nước bể hiếu khí
        [DisplayName("MLSS1")]
        public double MLSS1HieuKhi { get; set; }
        [DisplayName("MLSS2")]
        public double MLSS2HieuKhi { get; set; }
        [DisplayName("MLVSS")]
        public double MLVSSHieuKhi { get; set; }
        [DisplayName("SV 30")]
        public double SV30HieuKhi { get; set; }
        [DisplayName("pH")]
        public double pHHieuKhi { get; set; }

        //Nước vô hồ sinh học
        [DisplayName("COD")]
        public double CODSinhHoc { get; set; }
        [DisplayName("NaCl")]
        public double NaClSinhHoc { get; set; }

        //Nước ra hệ thống
        [DisplayName("COD")]
        public double CODHeThong { get; set; }
        [DisplayName("BOD")]
        public double BODHeThong { get; set; }
        [DisplayName("SS")]
        public double SSHeThong { get; set; }
        [DisplayName("Độ màu")]
        public double DoMauHeThong { get; set; }
        [DisplayName("N Tổng")]
        public double NTongHeThong { get; set; }
        [DisplayName("Nhiệt đọ")]
        public double NhietDoHeThong { get; set; }
        [DisplayName("P Tổng")]
        public double PTongHeThong { get; set; }
        [DisplayName("NT(m3)")]
        public double NTHeThong { get; set; }
    }
}
