using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MFF.WEB.Models
{
    public class ThemDanhMucUpsertModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được bỏ trống")]
        [DisplayName("Tên danh mục")]
        public string? TenDanhMuc { get; set; }

        [Required(ErrorMessage = "Mã danh mục không được bỏ trống")]
        [DisplayName("Mã danh mục")]
        public string? MaDanhMuc { get; set; }

        [Required(ErrorMessage = "Ưu tiên không được bỏ trống")]
        [DisplayName("Ưu tiên")]
        [Range(0, int.MaxValue, ErrorMessage = "Dữ liệu phải là số nguyên")]
        public int? UuTien { get; set; }

        [DisplayName("MoTa")]
        public string MoTa { get; set; }
    }
}
