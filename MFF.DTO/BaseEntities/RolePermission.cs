using System.ComponentModel.DataAnnotations.Schema;

namespace MFF.DTO.BaseEntities
{
    public class RolePermission : GuIdEntity
    {
        public string RoleId { get; set; }
        public string Permission { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
