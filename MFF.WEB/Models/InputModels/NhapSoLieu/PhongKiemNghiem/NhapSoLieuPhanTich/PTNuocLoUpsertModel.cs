﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MFF.WEB.Models
{
    public class PTNuocLoUpsertModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ngày không được bỏ trống")]
        [DisplayName("Ngày")]
        public DateTime? Ngay { get; set; }

        [Required(ErrorMessage = "Mã số ca không được bỏ trống")]
        [DisplayName("Mã số ca")]
        public string? MaSoCa { get; set; }

        [Required(ErrorMessage = "Giờ không được bỏ trống")]
        [DisplayName("GIờ")]
        public string? Gio { get; set; }

        [Required(ErrorMessage = "CaSX")]
        [DisplayName("CaSX")]
        public string? CaSX { get; set; }

        [Required(ErrorMessage = "CaKN")]
        [DisplayName("CaKN")]
        public string? CaKN { get; set; }

        [DisplayName("Lệnh sản xuất")]
        public string? LenhSanXuat { get; set; }

        [DisplayName("Danh mục")]
        public List<DanhMucItemModel> DanhMuc { get; set; }
    }
}