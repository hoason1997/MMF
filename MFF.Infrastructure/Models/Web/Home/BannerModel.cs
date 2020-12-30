using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.Infrastructure.Models
{
    public class BannerModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public int Order { get; set; }
        public bool IsPublish { get; set; }
    }
}
