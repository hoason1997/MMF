using System.Collections.Generic;

namespace MFF.DTO.BaseEntities
{
    public class Role : GuIdEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<RolePermission> Permissions { get; set; }
    }
}
