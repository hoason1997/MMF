using System.ComponentModel.DataAnnotations.Schema;

namespace MFF.DTO.BaseEntities
{
    public class UserRole : GuIdEntity
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
