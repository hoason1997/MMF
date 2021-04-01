using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class BCKNNuocLoHNViewModel
    {
        [DisplayName("Giờ")]
        public string Gio { get; set; }
        [DisplayName("Ca Sx")]
        public string CaSx { get; set; }

        //Nước lò
        [DisplayName("pH")]
        public double pHNuocLo { get; set; }
        [DisplayName("CO2")]
        public double CO2NuocLo { get; set; }
        [DisplayName("Đ")]
        public int DNuocLo { get; set; }
        [DisplayName("ĐC")]
        public int DCNuocLo { get; set; }
        [DisplayName("PP")]
        public double PPNuocLo { get; set; }
        [DisplayName("MO")]
        public double MONuocLo { get; set; }
        [DisplayName("PO4")]
        public double PO4NuocLo { get; set; }
        [DisplayName("SO3")]
        public double SO3NuocLo { get; set; }
        [DisplayName("TS")]
        public double TSNuocLo { get; set; }

        //Nước thủy cục
        [DisplayName("pH")]
        public double pHNuocThuyCuc { get; set; }
        [DisplayName("ĐC")]
        public int DCNuocThuyCuc { get; set; }
        [DisplayName("CL")]
        public double CLNuocThuyCuc { get; set; }

        //Nước cấp lò G2
        [DisplayName("pH")]
        public double pHNuocLoG2 { get; set; }
        [DisplayName("Đ")]
        public int DNuocLoG2 { get; set; }
        [DisplayName("ĐC")]
        public int DCNuocLoG2 { get; set; }

        //Nước mềm
        [DisplayName("pH")]
        public double pHNuocMem { get; set; }
        [DisplayName("ĐC")]
        public int DCNuocMem { get; set; }

        //Thùng
        [DisplayName("pH")]
        public double pHThung { get; set; }

        //Thùng F5-3
        [DisplayName("pH")]
        public double pHNuocThungF53 { get; set; }
        [DisplayName("Đ")]
        public int DNuocThungF53 { get; set; }
        [DisplayName("ĐC")]
        public int DCNuocThungF53 { get; set; }

        //Thử đường các nồi
        [DisplayName("N1")]
        public int N1 { get; set; }
        [DisplayName("N2")]
        public int N2 { get; set; }
        [DisplayName("N3")]
        public int N3 { get; set; }
        [DisplayName("N4")]
        public int N4 { get; set; }
        [DisplayName("N5")]
        public int N5 { get; set; }
        [DisplayName("N6")]
        public int N6 { get; set; }

        //Thử đường các cột
        [DisplayName("C1")]
        public int C1 { get; set; }
        [DisplayName("C2")]
        public int C2 { get; set; }
        [DisplayName("C3")]
        public int C3 { get; set; }
        [DisplayName("C4")]
        public int C4 { get; set; }
    }
}
