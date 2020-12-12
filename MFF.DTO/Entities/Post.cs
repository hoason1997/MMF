using MFF.DTO.BaseEntities;
using System;

namespace MFF.DTO.Entities
{
    public class Post : GuIdEntity
    {
        public string Alias { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CategoryId { get; set; }
        public string ShortDescription { get; set; }
        public string Tag { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public bool IsPublish { get; set; }
        public DateTime PublishDate { get; set; }
        //public virtual Category Category { get; set; }
    }
}
