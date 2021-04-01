using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MFF.WEB.Models
{
    public class LuongTonBCPUpsertModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ngày không được phép bỏ trống")]
        [DisplayName("Ngày")]
        public DateTime? Ngay { get; set; }
            
        [Required(ErrorMessage = "Trậng thái không được phép bỏ trống")]
        [DisplayName("Trạng thái")]
        public DateTime? TrangThai { get; set; }

        [DisplayName("Danh mục")]
        public List<DanhMucItemModel> DanhMuc { get; set; }

    }
}
