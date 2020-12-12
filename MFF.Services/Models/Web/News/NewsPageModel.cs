namespace MFF.Infrastructure.Models
{
    public class NewsPageModel
    {
        public int? Page { get; set; } = 1;
        public int? Type { get; set; } = 1;
        public WebsiteModel Website { get; set; }
    }
}
