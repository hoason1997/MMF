using MFF.DTO.BaseEntities;
using System.ComponentModel;

namespace MFF.DTO.Entities
{
    public enum ContactType
    {
        [Description("MFF Customer app")]
        CustomerApp = 1,
        [Description("MFF Crew app")]
        CrewApp = 2,
        [Description("Others")]
        Other = 3
    }
    public class ContactMessage : GuIdEntity
    {
        public string Title { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Message { get; set; }
        public ContactType ContactType { get; set; }
    }
}
