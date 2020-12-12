using MFF.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.Infrastructure.Models
{
    public class FooterModel
    {
        public FooterModel()
        {
            Website = new WebsiteModel();
            SocialNetwork = new SocialNetworkModel();
        }
        public string BaseUrl { get; set; }
        public WebsiteModel Website { get; set; }
        public SocialNetworkModel SocialNetwork { get; set; }
    }
}
