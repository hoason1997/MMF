﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MFF.WEB.Models
{
    public class VatTuHoaChatUpsertModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ngày không được phép bỏ trống")]
        [DisplayName("Ngày")]
        public DateTime? Ngay { get; set; }

        [DisplayName("Danh mục vật tư")]
        public string DanhMucVatTu { get; set; }

        [DisplayName("Danh mục")]
        public List<DanhMucItemModel> DanhMuc { get; set; }
    }
}