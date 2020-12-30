using MFF.DTO.BaseEntities;
using System;
using System.ComponentModel.DataAnnotations;

namespace MFF.DTO.Entities.SmartLab
{
    public class CanDongBao : GuIdEntity
    {
        [Key]
        public int Ma_CanDongBao { get; set; }
        public int? Khoa_CanDongBao { get; set; }
        public int? Ma_CttvThuocBang { get; set; }
        public int? Ma_SoCa  { get; set; }
        public DateTime? Ngay { get; set; }
        public decimal? GiaTri { get; set; }
        public bool? Xoa { get; set; }
        public string TaoBoi { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string CapNhatBoi { get; set; }     
    }
}
