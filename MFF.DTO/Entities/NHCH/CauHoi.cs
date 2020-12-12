using MFF.DTO.BaseEntities;
using System;
using System.ComponentModel.DataAnnotations;

namespace MFF.DTO.Entities.NHCH
{
    public class CauHoi : GuIdEntity
    {
        [Key]
        public int CauHoiID { get; set; }
        public string TenCauHoi { get; set; }
        public string TenCauHoiPhu { get; set; }
        //public string UrlCauHoi { get; set; }
        //public string NoiDungCauHoi { get; set; }
        //public DateTime? NgayHoi { get; set; }
        //public string NguoiTraLoi { get; set; }
        //public DateTime? NgayTraLoi { get; set; }
        public string NoiDungTraLoi { get; set; }     
    }
}
