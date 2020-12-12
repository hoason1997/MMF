using MFF.DTO.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MFF.Infrastructure.Models
{
    public class UserUpdateModel
    {
        [Required]
        [RegularExpression(Constant.EMAIL_REGEX, ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Title { get; set; }

        public bool IsActive { get; set; }

        public string FullName => string.IsNullOrEmpty(MiddleName) ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleName} {LastName}";

        public IEnumerable<UserRoleItem> Roles { get; set; }
    }
}
