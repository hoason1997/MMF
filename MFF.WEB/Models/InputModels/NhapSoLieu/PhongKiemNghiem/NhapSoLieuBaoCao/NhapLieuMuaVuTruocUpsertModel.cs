using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MFF.WEB.Models
{
    public class NhapLieuMuaVuTruocUpsertModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ngày không được phép bỏ trống")]
        [DisplayName("Ngày")]
        public DateTime? Ngay { get; set; }

        [Required(ErrorMessage = "Số thứ tự không được phép bỏ trống")]
        [DisplayName("Số thứ tự")]
        public string? SoThuTuTrongVu { get; set; }

        [DisplayName("LenhSanXuat")]
        public string LenhSanXuat { get; set; }

        [DisplayName("Danh mục")]
        public List<DanhMucItemModel> DanhMuc { get; set; }
    }
}
