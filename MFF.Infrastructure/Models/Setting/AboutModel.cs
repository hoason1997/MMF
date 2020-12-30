using MFF.DTO.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MFF.Infrastructure.Models
{
    public class AboutModel
    {
        public AboutModel()
        {
            Items = new List<AboutItemModel>();
            Pioneers = new List<PioneerModel>();
            Effectives = new EffectiveModel();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AboutItemModel> Items { get; set; }
        public List<PioneerModel> Pioneers { get; set; }
        public string AppIntroImageUrl { get; set; }
        public string IntroVideoUrl { get; set; }
        public string IntroVideoThumbnail { get; set; }
        public EffectiveModel Effectives { get; set; }
    }

    public class AboutItemModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        [RegularExpression(Constant.RegexValidateImage, ErrorMessage = "{0} is invalid image format")]
        public string Image { get; set; }
        public string Link { get; set; }
    }

    public class PioneerModel
    {
        [MaxLength(100, ErrorMessage = "{0} length can not be more than {1}.")]
        public string FullName { get; set; }
        [MaxLength(50, ErrorMessage = "{0} length can not be more than {1}.")]
        public string Title { get; set; }
        [MaxLength(5000, ErrorMessage = "{0} length can not be more than {1}.")]
        public string Introduction { get; set; }
        [RegularExpression(Constant.RegexValidateImage, ErrorMessage = "{0} is invalid image format")]
        public string Image { get; set; }
    }

    public class AboutUpdateModel
    {
        public AboutUpdateModel()
        {
            Advantages = new List<string>();
            Pioneers = new List<PioneerModel>();
        }
        public List<string> Advantages { get; set; }
        public List<PioneerModel> Pioneers { get; set; }
        [RegularExpression(Constant.RegexValidateImage, ErrorMessage = "{0} is invalid image format")]
        public string AppIntroImage { get; set; }
        public string IntroVideo { get; set; }
        [RegularExpression(Constant.RegexValidateImage, ErrorMessage = "{0} is invalid image format")]
        public string IntroVideoThumbnail { get; set; }
        [Range(0, 999999, ErrorMessage = "Please enter valid Number")]
        public int EffectiveVanNumber { get; set; }
        [Range(0, 999999, ErrorMessage = "Please enter valid Number")]
        public int EffectiveProductNumber { get; set; }
        [Range(0, 999999, ErrorMessage = "Please enter valid Number")]
        public int EffectiveEmployeesNumber { get; set; }
    }

}
