using MFF.DTO.Constants;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MFF.Infrastructure.Models
{
    public class WebsiteModel
    {
        public WebsiteModel()
        {
            Sliders = new List<SliderModel>();
            About = new AboutModel();
        }
        public string WebsiteName { get; set; }
        public string Title { get; set; }

        public string Slogan { get; set; }
        public string BannerImage { get; set; }//USING_SETTING
        public string Logo { get; set; }//USING_SETTING
        public string FooterLogo { get; set; }//USING_SETTING
        public string Favicon { get; set; }
        public List<SliderModel> Sliders { get; set; }//USING_SETTING
        public AboutModel About { get; set; }//USING_SETTING
    }

    public class SliderModel
    {
        public string Link { get; set; }
    }

    public class WebsiteSettingUploadModel
    {
        //[Required]
        [RegularExpression(Constant.RegexValidateImage, ErrorMessage = "{0} is invalid image format")]
        public string BannerImage { get; set; }
        //[Required]
        [RegularExpression(Constant.RegexValidateImage, ErrorMessage = "{0} is invalid image format")]
        public string LogoImage { get; set; }
        //[Required]
        [RegularExpression(Constant.RegexValidateImage, ErrorMessage = "{0} is invalid image format")]
        public string FooterLogoImage { get; set; }
        //[Required]
        //[RequiredCustom(ErrorMessage = "All Slider Images are required")]
        [ListIsValid(ErrorMessage = "{0} is invalid image format")]
        public List<string> SliderImages { get; set; }

    }

    public class ListIsValid : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var sliders = value as IEnumerable;
            var regex = new Regex(Constant.RegexValidateImage);
            foreach (string slider in sliders)
            {
                if (!string.IsNullOrEmpty(slider) && !regex.IsMatch(slider))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }

    public class RequiredCustom : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var sliders = value as IEnumerable;
            foreach (string slider in sliders)
            {
                if (string.IsNullOrEmpty(slider))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }

}
