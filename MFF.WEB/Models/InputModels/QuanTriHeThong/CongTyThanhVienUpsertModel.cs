using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class CongTyThanhVienUpsertModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên công ty không được bỏ trống")]
        [DisplayName("Tên công ty")]
        public string? TenCongTy { get; set; }

        [Required(ErrorMessage = "Mã chứng khoán không được bỏ trống")]
        [DisplayName("Mã chứng khoán")]
        public string? MaChungKhoan { get; set; }

        [Required(ErrorMessage = "Email không được bỏ trống")]
        [DisplayName("Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Màu menu con không được bỏ trống")]
        [DisplayName("Màu nền Menu con")]
        public string? MauNenMenuCon { get; set; }

        [Required(ErrorMessage = "Màu menu cha không được bỏ trống")]
        [DisplayName("Màu nền Menu cha")]
        public string? MauNenMenuCha { get; set; }

        [Required(ErrorMessage = "Logo không được bỏ trống")]
        [DisplayName("Logo")]
        public IFormFile? Logo { get; set; }

        [Required(ErrorMessage = "Hình bên trái không được bỏ trống")]
        [DisplayName("Hình bên trái")]
        public IFormFile? HinhBenTrai { get; set; }

        [Required(ErrorMessage = "Hình giữa không được bỏ trống")]
        [DisplayName("Hình giữa")]
        public IFormFile? HinhGiua { get; set; }

        [Required(ErrorMessage = "Hình ngang không được bỏ trống")]
        [DisplayName("Hình ngang")]
        public IFormFile? HinhNgang { get; set; }

        [DisplayName("Mô tả")]
        public string MoTa { get; set; }
    }
}
