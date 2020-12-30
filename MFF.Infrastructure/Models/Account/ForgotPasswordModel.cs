using MFF.DTO.Constants;
using System.ComponentModel.DataAnnotations;

namespace MFF.Infrastructure.Models
{
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = MessageConstant.EMAIL_IS_REQUIRED)]
        [RegularExpression(Constant.EMAIL_REGEX, ErrorMessage = MessageConstant.EMAIL_INVALID_FORMAT)]
        public string Email { get; set; }
    }
}
