using System;
using System.Collections.Generic;
using System.Text;

namespace MFF.Infrastructure.Models
{
    public class AppStoreModel
    {
        public string Title { get; set; }
        public string QrCodeAndroid { get; set; }
        public string LinkAndroid { get; set; }
        public string QrCodeApple { get; set; }
        public string LinkApple { get; set; }
        public string BannerImage { get; set; }
    }
}
