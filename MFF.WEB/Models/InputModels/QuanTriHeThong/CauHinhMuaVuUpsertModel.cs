using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MFF.WEB.Models
{
    public class CauHinhMuaVuUpsertModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Danh sách công ty thành viên")]
        public string DanhSachCongTyThanhVien { get; set; }

        [Required(ErrorMessage = "Ngày bắt đầu không được phép bỏ trống")]
        [DisplayName("Ngày bắt đầu vụ")]
        public DateTime? NgayBatDauVu { get; set; }

        [Required(ErrorMessage = "Ngày kết thúc không được phép bỏ trống")]
        [DisplayName("Ngày kết thúc vụ")]
        public DateTime? NgayKetThucVu { get; set; }

        [DisplayName("Mô tả")]
        public string MoTa { get; set; }
    }
}
