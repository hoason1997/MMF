using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MFF.WEB.Models
{
    public class CacPhongBanModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được phép bỏ trống")]
        [DisplayName("Tiêu đề")]
        public string TieuDe { get; set; }

        [Required(ErrorMessage = "Ngày không được phép bỏ trống")]
        [DisplayName("Ngày kết thúc công việc")]
        public DateTime? NgayKetThucCongViec { get; set; }

        [Required(ErrorMessage = "Giờ không được phép bỏ trống")]
        [DisplayName("Giờ kết thúc công việc")]
        public string? Gio { get; set; }

        [Required(ErrorMessage = "Người thực hiện không được phép bỏ trống")]
        [DisplayName("Người thực hiện")]
        public string? NguoiThucHien { get; set; }

        [Required(ErrorMessage = "Trạng thái không được phép bỏ trống")]
        [DisplayName("Trạng thái")]
        public string? TrangThai { get; set; }

        [Required(ErrorMessage = "Phòng ban không được phép bỏ trống")]
        [DisplayName("Phòng ban")]
        public string? ThuocPhongban { get; set; }

        [Required(ErrorMessage = "Người nhận không được trống")]
        [DisplayName("Người nhận")]
        public List<string> NguoiNhan { get; set; }

        [Required(ErrorMessage = "Nội dung không được phép bỏ trống")]
        [DisplayName("Nội dung")]
        public string? NoiDung { get; set; }
    }
}
