using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class BCKNBaoCaoSanXuatTheoGiaiDoanViewModel
    {
        [DisplayName("Diễn giải")]
        public string DienGiai { get; set; }
        [DisplayName("Đơn vị")]
        public string DonVi { get; set; }
        [DisplayName("Thời đoạn")]
        public string ThoiDoan { get; set; }
    }
}
