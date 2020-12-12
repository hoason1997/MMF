using System.ComponentModel.DataAnnotations;

namespace MFF.WEB.Models.MFF
{
    public class CreateViewModel
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
    }
}
