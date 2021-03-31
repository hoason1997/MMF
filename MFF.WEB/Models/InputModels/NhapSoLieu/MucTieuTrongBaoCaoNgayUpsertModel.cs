using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MFF.WEB.Models
{
    public class MucTieuTrongBaoCaoNgayUpsertModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Mùa vụ không được bỏ trống")]
        [DisplayName("Chọn mùa vụ thực hiện một tiêu")]
        public string MuaVu { get; set; }

        public List<string> DanhMuc { get; set; }
    }
}
