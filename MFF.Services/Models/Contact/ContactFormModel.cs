using MFF.DTO.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MFF.Infrastructure.Models
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Contact name")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^(?:\+?1[-. ]?)?\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone is not valid")]
        public string ContactPhone { get; set; }

        [RegularExpression("^(?!^\\.|_)(?!.*[-_.]@)(?!.*?\\.\\.)(?!.*?\\._)(?!.*?_\\.)[(?!.*?__)a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-_]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Required(ErrorMessage = "Email is required")]
        public string ContactEmail { get; set; }

        public ContactType ContactType { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Subjects is required")]
        public string Title { get; set; }

        public List<KeyValuePair<int, string>> Subjects { get; set; }

    }
    public class ContactFormPassModel
    {
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public ContactType ContactType { get; set; }
        public string Message { get; set; }

    }

    public class ContactFormPassNameModel
    {
        public string Name { get; set; }

    }
}
