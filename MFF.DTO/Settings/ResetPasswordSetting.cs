namespace MFF.DTO.Settings
{
    public class ResetPasswordSetting
    {
        public int LinkExpiredInMinutes { get; set; }
        public string ResetPasswordLink { get; set; }
    }
}
