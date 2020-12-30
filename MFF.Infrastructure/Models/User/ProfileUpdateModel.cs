using MFF.DTO.Constants;
using System.ComponentModel.DataAnnotations;

namespace MFF.Infrastructure.Models
{
    public class ProfileUpdateModel
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(20, ErrorMessage = "First name length can't be more than {1}.")]
        public string FirstName { get; set; }

        [StringLength(10, ErrorMessage = "Middle name length can't be more than {1}.")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(20, ErrorMessage = "Last name length can't be more than {1}.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(15, ErrorMessage = "Phone number length can't be more than {1}.")]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(Constant.EMAIL_REGEX, ErrorMessage = "Email format is incorrect.")]
        public string Email { get; set; }

        public string AvatarUrl { get; set; }
    }
}
