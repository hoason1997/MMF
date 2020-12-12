using MFF.DTO.Entities;
using System;

namespace MFF.Infrastructure.Models
{
    public class ContactResponseModel
    {
        public string Title { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Message { get; set; }
        public ContactType ContactType { get; set; }
    }
}
