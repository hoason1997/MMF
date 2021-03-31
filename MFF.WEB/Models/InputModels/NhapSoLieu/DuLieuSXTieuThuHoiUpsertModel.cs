using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class DuLieuSXTieuThuHoiUpsertModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ngày không được phép bỏ trống")]
        [DisplayName("Ngày")]
        public DateTime? Ngay { get; set; }

        [Required(ErrorMessage = "Mã số ca không được phép bỏ trống")]
        [DisplayName("Mã số ca")]
        public string? MaSoCa { get; set; }

        [DisplayName("Nước cấp lò")]
        [Range(0, double.MaxValue, ErrorMessage = "Thể tích không hợp lệ")]
        public double NuocCapLo { get; set; }

        [DisplayName("Nước mềm bổ sung")]
        [Range(0, double.MaxValue, ErrorMessage = "Thể tích không hợp lệ")]
        public double NuocMemBoSung { get; set; }

        [DisplayName("Hơi")]
        [Range(0, double.MaxValue, ErrorMessage = "Áp suất không hợp lệ")]
        public double Hoi { get; set; }

        [DisplayName("Hơi (đồng hồ)")]
        [Range(0, double.MaxValue, ErrorMessage = "Áp suất không hợp lệ")]
        public double HoiDongHo { get; set; }

        [DisplayName("Than đá nhập")]
        [Range(0, double.MaxValue, ErrorMessage = "Cân nặng không hợp lệ")]
        public double ThanDaNhap { get; set; }

        [DisplayName("Than đá tiêu thụ")]
        [Range(0, double.MaxValue, ErrorMessage = "Cân nặng không hợp lệ")]
        public double ThanDaTieuThu { get; set; }

        [DisplayName("Than nâu nhập")]
        [Range(0, double.MaxValue, ErrorMessage = "Cân nặng không hợp lệ")]
        public double ThanNauNhap { get; set; }

        [DisplayName("Than nâu tiêu thụ")]
        [Range(0, double.MaxValue, ErrorMessage = "Cân nặng không hợp lệ")]
        public double ThanNâuTieuThu { get; set; }
    }
}
