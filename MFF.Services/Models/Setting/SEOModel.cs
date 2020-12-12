using MFF.DTO.Enums;

namespace MFF.Infrastructure.Models
{
    public class SEOModel
    {
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public PageType PageType { get; set; }
    }
}
