using MFF.DTO.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MFF.Infrastructure.Models
{
    public class UserAddModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(Constant.PASSWORD_REGEX, ErrorMessage = MessageConstant.PASSWORD_INVALID_FORMAT)]
        public string Password { get; set; }

        [Required]
        [RegularExpression(Constant.EMAIL_REGEX, ErrorMessage = MessageConstant.EMAIL_INVALID_FORMAT)]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Title { get; set; }

        public string FullName => string.IsNullOrEmpty(MiddleName) ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleName} {LastName}";

        public IEnumerable<UserRoleItem> Roles { get; set; }
    }
}
