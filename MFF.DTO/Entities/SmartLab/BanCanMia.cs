using MFF.DTO.BaseEntities;
using System;
using System.ComponentModel.DataAnnotations;

namespace MFF.DTO.Entities.SmartLab
{
    public class BanCanMia :BaseEntity
    {
        [Key]
        public int Ma_BanCanMia  { get; set; }
        public int? Ma_SoCa { get; set; }
        public int? Ma_Cttv { get; set; }
        public DateTime? Ngay { get; set; }
        public string Gio { get; set; }
        public decimal? TanMia { get; set; }
        public decimal? TanMiaTho { get; set; }
        public bool? Xoa { get; set; }
        public string Mota { get; set; }     
    }
}
