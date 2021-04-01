using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class BCKNBaoCaoSanXuatTheoNgayViewModel
    {
        [DisplayName("Diễn giải")]
        public string DienGiai { get; set; }
        [DisplayName("Đơn vị")]
        public string DonVi { get; set; }
        [DisplayName("Ngày")]
        public string Ngay { get; set; }
        [DisplayName("Tuần")]
        public string Tuan { get; set; }
        [DisplayName("Tháng")]
        public string Thang { get; set; }
        [DisplayName("Kỳ")]
        public string Ky { get; set; }
        [DisplayName("Vụ")]
        public string Vu { get; set; }
    }
}
