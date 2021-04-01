using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MFF.WEB.Models
{
    public class NhapSoLieuLamBaoCaoNgayUpsertModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ngày không được phép bỏ trống")]
        [DisplayName("Ngày")]
        public DateTime? Ngay { get; set; }

        [DisplayName("Trạng thái")]
        public string TrangThai { get; set; }

        [DisplayName("Lệnh sản xuất")]
        public string LenhSanXuat { get; set; }

        [DisplayName("Danh mục")]
        public List<DanhMucItemModel> DanhMuc { get; set; }
    }
}
