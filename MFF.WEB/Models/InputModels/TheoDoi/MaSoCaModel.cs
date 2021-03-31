using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MFF.WEB.Models
{
    public class MaSoCaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã số ca không được phép bỏ trống")]
        [DisplayName("Mã số ca")]
        public string? MaSoCa { get; set; }

        [Required(ErrorMessage = "Giờ không được phép bỏ trống")]
        [DisplayName("Giờ kết thúc công việc")]
        public string? Gio { get; set; }

        [Required(ErrorMessage = "Sự cố không được phép bỏ trống")]
        [DisplayName("Sự cố")]
        public string? SuCo { get; set; }

        [Required(ErrorMessage = "Thiết bị không được phép bỏ trống")]
        [DisplayName("Thiết bị")]
        public string? ThietBi { get; set; }

        [Required(ErrorMessage = "Mã thiết bị không được phép bỏ trống")]
        [DisplayName("Mã thiết bị")]
        public string? MaThietBi { get; set; }

        [Required(ErrorMessage = "Khu vực không được phép bỏ trống")]
        [DisplayName("Khu vực")]
        public string? KhuVuc { get; set; }

        [Required(ErrorMessage = "Người xử lý không được phép bỏ trống")]
        [DisplayName("Người xử lý")]
        public string? NguoiXuLy { get; set; }

        [Required(ErrorMessage = "Số phút sự cố không được phép bỏ trống")]
        [DisplayName("Số phút sự cố")]
        [Range(1,60, ErrorMessage = "Số phút không hợp lệ")]
        public int? SoPhutSuCo { get; set; }

        [Required(ErrorMessage = "Số phút ngưng ép/hòa tan không được phép bỏ trống")]
        [DisplayName("Số phút ngưng ép/hòa tan")]
        [Range(1, 60, ErrorMessage = "Số phút không hợp lệ")]
        public int? SoPhutNgungEpHoaTan { get; set; }

        [Required(ErrorMessage = "Nguyên nhân không được phép bỏ trống")]
        [DisplayName("Nguyên nhân")]
        public string? NguyenNhan { get; set; }

        [Required(ErrorMessage = "Khắc phục không được phép bỏ trống")]
        [DisplayName("Khắc Phục")]
        public string? KhacPhuc { get; set; }

        [Required(ErrorMessage = "Phòng ngừa không được phép bỏ trống")]
        [DisplayName("Phòng ngừa")]
        public string? PhongNgua { get; set; }

        [Required(ErrorMessage = "Điều chỉnh không được phép bỏ trống")]
        [DisplayName("Điều chỉnh")]
        public string? DieuChinh { get; set; }

        [DisplayName("Loại sự cố")]
        public string? LoaiSuCo { get; set; }
    }
}
