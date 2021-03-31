using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class ChiDaoSanXuatUpsertModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được phép bỏ trống")]
        [DisplayName("Tiêu đề công việc")]
        public string? TieuDe { get; set; }

        [Required(ErrorMessage = "Ngày không được phép bỏ trống")]
        [DisplayName("Ngày kết thúc công việc")]
        public DateTime? NgayKetThucCongViec { get; set; }

        [DisplayName("Giờ kết thúc công việc")]
        public string Gio { get; set; }


        [Required(ErrorMessage = "Người thực hiện không được phép bỏ trống")]
        [DisplayName("Người thực hiện")]
        public string? NguoiThucHien { get; set; }

        [DisplayName("Trạng thái")]
        public string TrangThai { get; set; }

        [DisplayName("Phòng ban")]
        public string ThuocPhongban { get; set; }

        [DisplayName("Nội dung")]
        public string NoiDung { get; set; }
    }
}
