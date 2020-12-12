using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.Infrastructure.Models
{
    public class CauHoiModel
    {
        public int CauHoiID { get; set; }
        public string TenCauHoi { get; set; }
        public string TenCauHoiPhu { get; set; } 
    }
    public class CauHoiDetailModel
    {
        public int CauHoiID { get; set; }
        public string TenCauHoi { get; set; }
        public string TenCauHoiPhu { get; set; }
        public string NoiDungCauHoi { get; set; }
        public string NoiDungTraLoi { get; set; }
    }
}
