using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MFF.WEB.Models.InputModels.NhapSoLieu
{
    public class ThucHienMucTieuVuUpsertModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Danh sách mùa vụ")]
        public string? DanhSachMuaVu { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được phép bỏ trống")]
        [DisplayName("Tiêu đề")]
        public string? TieuDe { get; set; }

        [DisplayName("Đường thô nhập máy")]
        [Range(0, double.MaxValue, ErrorMessage = "Cân nặng không hợp lệ")]
        public double DuongThoNhapMay { get; set; }

        [DisplayName("Đường TP đóng bao")]
        [Range(0, double.MaxValue, ErrorMessage = "Cân nặng không hợp lệ")]
        public double DuongTPDongBao { get; set; }

        [DisplayName("Mô tả")]
        public string MoTa { get; set; }
    }
}
