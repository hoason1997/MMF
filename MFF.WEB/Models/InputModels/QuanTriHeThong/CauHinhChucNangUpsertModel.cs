using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MFF.WEB.Models
{
    public class CauHinhChucNangUpsertModel
    {
        //Them cau hinh bang
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được bỏ trống")]
        [DisplayName("Tên danh mục")]
        public string? TenDanhMuc { get; set; }

        [DisplayName("Danh mục cha")]
        public string DanhMucCha { get; set; }

        [DisplayName("Mã danh mục")]
        public string MaDanhMuc { get; set; }

        [DisplayName("Mã ERP")]
        public string MaERP { get; set; }

        [DisplayName("Thứ tự")]
        [Range(0, int.MaxValue, ErrorMessage = "Phải là số nguyên")]
        public int ThuTu { get; set; }

        [DisplayName("MoTa")]
        public string MoTa { get; set; }
    }
}
