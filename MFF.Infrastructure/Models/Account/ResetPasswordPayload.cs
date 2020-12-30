namespace MFF.Infrastructure.Models
{
    public class ResetPasswordPayload
    {
        public string UserId { get; set; }
        public string DateUTC { get; set; }
    }
}
