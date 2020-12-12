using System.Collections.Generic;

namespace MFF.DTO.BaseEntities
{
    public class User : GuIdEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public bool IsSystemAccount { get; set; }
        public string FullName { get; set; }
        public string AvatarUrl { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
