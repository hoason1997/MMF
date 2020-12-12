using System;
using System.Collections.Generic;
using System.Text;

namespace MFF.Infrastructure.Models
{
    public class NewsIndexModel
    {
        public string Id { get; set; }
        public string Alias { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
    }
}
