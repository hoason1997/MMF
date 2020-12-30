using MFF.DTO.Enums;

namespace MFF.Infrastructure.Models
{
    public class HeaderModel
    {
        public HeaderModel()
        {
            Website = new WebsiteModel();
        }
        public string BaseUrl { get; set; }
        public WebsiteModel Website { get; set; }
        public PageType PageType { get; set; }
    }
}
