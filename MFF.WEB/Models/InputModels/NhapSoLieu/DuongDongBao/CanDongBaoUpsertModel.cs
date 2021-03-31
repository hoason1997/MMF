using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MFF.WEB.Models
{
    public class CanDongBaoUpsertModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ngày không được phép bỏ trống")]
        [DisplayName("Ngày")]
        public DateTime? Ngay { get; set; }

        [Required(ErrorMessage = "Mã số ca không được phép bỏ trống")]
        [DisplayName("Mã số ca")]
        public string? MaSoCa { get; set; }

        [Required(ErrorMessage = "Giờ không được phép bỏ trống")]
        [DisplayName("Giờ")]
        public string? Gio { get; set; }

        [DisplayName("Cân 1A")]
        [Range(0, double.MaxValue, ErrorMessage = "Cân nặng không hợp lệ")]
        public double Can1A { get; set; }

        [DisplayName("Cân 1B")]
        [Range(0, double.MaxValue, ErrorMessage = "Cân nặng không hợp lệ")]
        public double Can1B { get; set; }

        [DisplayName("Mô tả")]
        public string MoTa { get; set; }
    }
}
