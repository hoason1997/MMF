namespace MFF.DTO.Settings
{
    public class BackOfficeSetting
    {
        public string EndPoint { get; set; }
        public string HeaderKey { get; set; }
        public string SecretKey { get; set; }
    }

    public class VNPaySetting
    {
        public string vnp_Url { get; set; }
        public string vnp_Returnurl { get; set; }
        public string vnpay_api_url { get; set; }
        public string vnp_TmnCode { get; set; }
        public string vnp_HashSecret { get; set; }
    }
}
