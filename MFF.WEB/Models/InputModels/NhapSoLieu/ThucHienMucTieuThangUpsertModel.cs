using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MFF.WEB.Models
{
    public class ThucHienMucTieuThangUpsertModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tháng không được phép bỏ trống")]
        [DisplayName("Chọn tháng")]
        [Range(1, 12, ErrorMessage = "Tháng không hợp lệ")]
        public int? ChonThang { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được phép bỏ trống")]
        [DisplayName("Tiêu đề")]
        public string? TieuDe { get; set; }

        [DisplayName("Đường thô nhập máy")]
        [Range(0, double.MaxValue, ErrorMessage = "Cân nặng không hợp lệ")]
        public double DuongThoNhapMay { get; set; }

        [DisplayName("Số ngày ngừng")]
        [Range(0, int.MaxValue, ErrorMessage = "Số ngày không hợp lệ")]
        public int SoNgayNgung1{ get; set; }

        [DisplayName("Đường TP đóng bao")]
        [Range(0, double.MaxValue, ErrorMessage = "Cân nặng không hợp lệ")]
        public double DuongTPDongBao { get; set; }

        [DisplayName("Số ngày ngừng")]
        [Range(0, int.MaxValue, ErrorMessage = "Số ngày không hợp lệ")]
        public int SoNgayNgung2 { get; set; }
    }
}
