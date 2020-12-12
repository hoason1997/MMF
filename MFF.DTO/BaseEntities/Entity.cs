using System;
using System.ComponentModel.DataAnnotations;

namespace MFF.DTO.BaseEntities
{
    public class Entity
    {
        public Entity()
        {
            CreatedTime = DateTime.UtcNow;
            UpdatedTime = DateTime.UtcNow;
        }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        //[Timestamp]
        //public byte[] RowVersion { get; set; }
    }
}
