namespace MFF.Infrastructure.Models
{
    public class LoginSuccessModel
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
        public UserProfileResponse UserProfile { get; set; }
    }
}
