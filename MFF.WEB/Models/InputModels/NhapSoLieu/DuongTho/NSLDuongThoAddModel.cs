using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class NSLDuongThoAddModel
    {
        //Nhap so lieu -> duong tho
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
        
        [Required(ErrorMessage = "Tấn đường thô không được bỏ trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Cân nặng không hợp lệ")]
        [DisplayName("Tấn đường thô")]
        public double? TanDuongTho { get; set; }

        [Required(ErrorMessage = "Pol không được phép bỏ trống")]
        [DisplayName("Loại Pol")]
        public string? LoaiPol { get; set; }

        [Required(ErrorMessage = "Tổng đường thô không được bỏ trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Cân nặng không hợp lệ")]
        [DisplayName("Tổng đường thô trong ca")]
        public double? TongDuongThoTrongCa { get; set; }

        [Required(ErrorMessage = "Tấn đường thô trong ca không được bỏ trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Cân nặng không hợp lệ")]
        [DisplayName("Tấn đường thô trong ca")]
        public double? TanDuongThoTrongNgay { get; set; }

        [Required(ErrorMessage = "Mô tả không được bỏ trống")]
        [DisplayName("Mô tả")]
        public string? MoTa { get; set; }
    }
}
