using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MFF.WEB.Models
{
    public class CauHinhCaUpsertModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã số ca không được phép bỏ trống")]
        [DisplayName("Mã số ca")]
        public string? MaSoCa { get; set; }

        [Required(ErrorMessage = "Ngày không được phép bỏ trống")]
        [DisplayName("Ngày")]
        public DateTime? Ngay { get; set; }

        [Required(ErrorMessage = "Ca sản xuất không được phép bỏ trống")]
        [DisplayName("Ca sản xuất")]
        public string? CaSX { get; set; }

        [Required(ErrorMessage = "Ca kiểm nghiệm không được phép bỏ trống")]
        [DisplayName("Ca kiểm nghiệm")]
        public string? CaKN { get; set; }

        [DisplayName("Mô tả")]
        public string MoTa { get; set; }
    }
}
