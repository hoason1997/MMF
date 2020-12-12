using MFF.DTO.BaseEntities;

namespace MFF.DTO.Entities
{
    public class Banner : GuIdEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public int Order { get; set; }
        public bool IsPublish { get; set; }
    }
}
