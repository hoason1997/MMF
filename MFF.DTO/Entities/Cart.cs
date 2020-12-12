using MFF.DTO.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFF.DTO.Entities
{
    public class Cart : GuIdEntity
    {
        public string Quanlity { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
