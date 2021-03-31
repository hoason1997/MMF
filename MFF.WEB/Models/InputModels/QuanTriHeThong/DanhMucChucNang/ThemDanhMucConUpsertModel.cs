using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MFF.WEB.Models
{
    public class ThemDanhMucConUpsertModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục con không được bỏ trống")]
        [DisplayName("Tên danh mục con")]
        public string? TenDanhMucCon { get; set; }

        [Required(ErrorMessage = "Danh mục cha không được bỏ trống")]
        [DisplayName("Danh mục cha")]
        public string? DanhMucCha { get; set; }

        [DisplayName("Tên danh mục con")]
        public string TenDanhMucConCha { get; set; }

        [Required(ErrorMessage = "Mã danh mục con không được bỏ trống")]
        [DisplayName("Mã danh mục con")]
        public string? MaDanhMucCon { get; set; }

        [Required(ErrorMessage = "Ưu tiên không được bỏ trống")]
        [DisplayName("Ưu tiên")]
        public string? UuTien { get; set; }

        [Required(ErrorMessage = "Đường dẫn không được bỏ trống")]
        [DisplayName("Đường dẫn")]
        public string DuongDan { get; set; }

        [DisplayName("MoTa")]
        public string MoTa { get; set; }
    }
}
