using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class DuongKhongPhuHopUpsertModel
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

        [Required(ErrorMessage = "Tấn đường không được phép bỏ trống")]
        [DisplayName("Tấn đườngkhông phù hợp")]
        [Range(0, double.MaxValue, ErrorMessage = "Cân nặng không hợp lệ")]
        public double? TanDuongThanhPhamQuaCan { get; set; }

        [DisplayName("Tổng đườngkhông phù hợp trong ca")]
        [Range(0, double.MaxValue, ErrorMessage = "Cân nặng không hợp lệ")]
        public double TongDuongThanhPhamQuaCanTrongCa { get; set; }

        [DisplayName("Tổng đườngkhông phù hợp trong ngày")]
        [Range(0, double.MaxValue, ErrorMessage = "Cân nặng không hợp lệ")]
        public double TongDuongThanhPhamQuaCanTrongNgay { get; set; }

        [DisplayName("Mô tả")]
        public string MoTa { get; set; }
    }
}
