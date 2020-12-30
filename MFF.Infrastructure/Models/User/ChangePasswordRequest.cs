using MFF.DTO.Constants;
using System.ComponentModel.DataAnnotations;

namespace MFF.Infrastructure.Models
{
    public class ChangePasswordRequest
    {
        [Required(ErrorMessage = MessageConstant.CHANGE_PASSWORD_OLD_PASSWORD_REQUIRED)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = MessageConstant.CHANGE_PASSWORD_NEW_PASSWORD_REQUIRED)]
        public string NewPassword { get; set; }
    }
}
