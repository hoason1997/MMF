using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MFF.WEB.Models
{
    public class SoGiaoCaSanXuatUpsertModel
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Ca không được bỏ trống")]
        [DisplayName("Ca")]
        public string? Ca { get; set; }

        [Required(ErrorMessage = "Kíp không được phép bỏ trống")]
        [DisplayName("Kíp")]
        public string? Kip { get; set; }

        [DisplayName("Thực hiện")]
        public string ThucHien { get; set; }

        [DisplayName("Bàn giao")]
        public string BanGiao { get; set; }
    }
}
