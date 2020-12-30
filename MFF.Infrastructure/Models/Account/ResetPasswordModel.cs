using MFF.DTO.Constants;
using System.ComponentModel.DataAnnotations;

namespace MFF.Infrastructure.Models
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = MessageConstant.RESET_PASSWORD_TOKEN_REQUIRED)]
        public string Token { get; set; }

        [Required(ErrorMessage = MessageConstant.RESET_PASSWORD_NEW_PASSWORD_REQUIRED)]
        public string Password { get; set; }
    }
}
