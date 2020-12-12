using System;
using System.Collections.Generic;
using System.Text;

namespace MFF.Infrastructure.Models
{
    public class ContactModel
    {
        public string Title { get; set; }
        public string Slogan { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public SocialNetworkModel SocialNetwork { get; set; }
    }
    public class SocialNetworkModel
    {
        public string Facebook { get; set; }
        public string Youtube { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Linkedin { get; set; }
    }
}
