using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.WEB.Models
{
    public class DanhMucItemModel
    {
        public int Id { get; set; }
        public int DanhMucId { get; set; }
        public string DanhMucItemName { get; set; }
        public string DanhMucItemValue { get; set; }
    }
}
