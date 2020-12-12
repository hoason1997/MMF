using System.Collections.Generic;
namespace MFF.DTO.Constants
{
    public static class Constant
    {
        public const char CLAIM_JOIN_CHAR = ',';

        public const string PASSWORD_REGEX = @"(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[#?!@$%^&*-])(?=.*?[0-9]).{8,}$";
        public const string EMAIL_REGEX = @"^(?=.*[a-zA-Z].*\@.*)(([a-zA-Z\d]+)(([_\.{1}])([a-zA-Z\d]+))*)?\@((([a-zA-Z\d]+)(([_\.{1}])([a-zA-Z\d]+))*)+)(\.(([a-zA-Z\d]+)(([_\.{1}])([a-zA-Z\d]+))*)+)+$";

        public const string ADMIN_USERNAME = "itadmin";
        public const string ADMIN_EMAIL = "huuchien.vn@gmail.com";
        public const string ADMIN_PASSWORD = "P@ssw0rd";

        public const string AREA_API = "Api";

        #region === Cache time ===
        public const int CacheTimeHours = 24;
        public const int CacheTimeSeconds = 86400;
        public const int CacheTimeMins = 15;
        public const int OutPutCacheTimeSeconds = 5;//86400;
        public const int FileCacheTimeHours = 24;
        public const int FileCacheTimeDays = 30;
        #endregion
        #region === Cache Clear ===
        public const string CacheClear = "/clear-cache";
        #endregion
        public const string INDEX_Ui_String_Key = "_index_ui_string_key";
        public const string INDEX_Ui_Key = "_index_ui_key";
        public const string NEWSINDEX_Ui_String_Key = "_news_index_ui_string_key";
        public const string NEWSDETAIL_Ui_String_Key = "_news_detail_ui_string_key";
        public const string NEWSINDEX_Ui_Key = "_news_index_ui_key";
        public const string TOPNEWS_Ui_Key = "_top_news_ui_key";
        public const string EVENTNEWS_Ui_Key = "_event_news_ui_key";
        public const string DETAILNEWS_Ui_Key = "_detail_news_ui_key";
        public const string PROMOTIONTNEWS_Ui_Key = "_promotion_news_ui_key";
        public const string ABOUT_INDEX_Ui_String_Key = "_about_index_ui_string_key";
        public const string TERM_INDEX_Ui_String_Key = "_term_index_ui_string_key";
        public const string TERM_INDEX_Ui_Key = "_term_index_ui_key";
        public const string ABOUT_INDEX_Ui_Key = "_about_index_ui_key";
        public const string HEADER_Ui_Key = "_header_ui_key";
        public const string FOOTER_Ui_Key = "_footer_ui_key";
        public const string BANNER_Ui_Key = "_banner_ui_key";
        public const string AboutUs_Ui_Key = "_AboutUs_ui_key";
        public const string AppStore_Ui_Key = "_AppStore_ui_key";
        public const string Feedback_Ui_Key = "_Feedback_ui_key";
        public const string Contact_Ui_Key = "_Contact_ui_key";
        public const string Contact_From_Ui_Key = "_Contact_form_ui_key";
        public const string Product_Ui_Key = "_Product_ui_key";
        public const string News_Ui_Key = "_News_ui_key";
        public const string Package_Ui_Key = "_Package_ui_key";
        public const string Effective_Ui_Key = "_Effective_ui_key";
        public const string LAYOUT_JsonLD = "_layout_jsonld_key";
        public const string Cart_Ui_Key = "_Cart_ui_Key";

        public const string FILE_PATH = "resources";

        public const string SETTING_Popup = "SETTING_Popup_key";
        public const string SETTING_PopupData = "SETTING_Popup_key_data";

        public const string SETTING_WebProfile = "SETTING_WebProfile_key";
        public const string SETTING_WebProfileData = "SETTING_WebProfile_key_data";

        public const string SETTING_AboutUs = "SETTING_AboutUs_key";
        public const string SETTING_AboutUsData = "SETTING_AboutUs_key_data";

        public const string SETTING_ContactInfo = "SETTING_ContactInfo_key";
        public const string SETTING_ContactInfoData = "SETTING_ContactInfo_key_data";

        public const string SETTING_AppStore = "SETTING_AppStore_key";
        public const string SETTING_AppStoreData = "SETTING_AppStore_key_data";

        public const string SETTING_Effective = "SETTING_Effective_key";
        public const string SETTING_EffectiveData = "SETTING_Effective_key_data";

        public const string SETTING_ProductDatas = "SETTING_Product_key_datas";
        public const string SETTING_TopBannerDatas = "SETTING_TopBanner_key_datas";
        public const string SETTING_TopFeedbackDatas = "SETTING_TopFeedback_key_datas";
        public const string SETTING_TopPostDatas = "SETTING_TopPost_key_datas";

        public const string SETTING_Seo = "SETTING_Seo_key";
        public const string SETTING_SeoData = "SETTING_Seo_key_data";

        public const string QueryFormat = ",{0},";
        public const string FileTime = "mmhhss";
        public const string DateTimeFormat = "MM/dd/yyyy";
        public const string DateTimeMiddayFormat = "MM/dd/yyyy hh:mm tt";
        public const int TopFeedbacks = 10;
        public const int TopIndexNews = 4;
        public const int TopNews = 4;
        public const int TopBanners = 5;
        public const int PagingSize = 5;
        public const int DurationInSeconds = 31536000;

        public const string ContactMessageTitle = "Contact message for {0}";

        public const string RegexDetectImage = "^data:image\\/[a-z]+;base64,";
        public const string RegexValidateImage = "^data:image\\/[a-z]+;base64,.*";

        #region About Us

        //MOBILE image
        public const string ADVANTAGES_MOBILE_IMAGE = "images/process-img-mobile.png";
        // UNSURPASSED QUALITY image 
        public const string ADVANTAGES_UNSURPASSED_QUALITY = "images/process-img-quality.png";
        // SATISFACTION GUARANTEE image
        public const string ADVANTAGES_SATISFACTION_GUARANTEE = "images/process-img.png";

        public const string APP_INTRO_IMAGE = "images/banner-phone-app.png";

        public const int Product_QUANTITY = 6;
        public const int VAN_QUANTITY = 11;
        public const int EMPLOYEE_QUANTITY = 25;

        public const string BACKGROUND_VIDEO = "images/about-us-page/background-video.png";
               
        public const string WEB_SITE_TITLE = "Metronic Detailing Services";
        public const string WEB_SITE_IMAGE = "images/logos/logo.png";
        public const string WEB_SITE_KEYWORD = "auto detailing service,autodetailingservice,detailing service,detailingservice,car wash,car washing,wash,Metronic detailing services,Metronicdetailingservices,application";
        public const string WEB_SITE_DESCRIPTION = "We are the ultimate mobile auto detailing service built on convenience, reliability and outstanding quality. We pride ourselves on creating “customers for life”. That’s why we offer a Satisfaction Guarantee program to ensure you get the exceptional service and results you’re looking for. Call now to schedule your same day wash or detailing service today. We're not satisfied until you're satisfied.";

        #endregion

        #region Route
        public const string AboutIndex = "/about";
        public const string ContactIndex = "/contact";
        public const string NewsIndex = "/news";
        public const string Sitemap = "/sitemap.xml";
        public const string RequestTokenKey = "/request-token-key";
        public const string NewsDetail = "/news/{alias}";
        public const string TermIndex = "/policy";
        public const string Error_Index = "/page-not-found";
        public const string Error_Index2 = "/sorry-page-not-found";
        public const string CONTACT_SendContact = "/contact/message-sent";
        public const string CONTACT_ThankYouContact = "/contact/thank-youk";
        #endregion

        #region Category Name
        public static Dictionary<int, string> CategoryListName = new Dictionary<int, string>()
        {
            { 1, "NEWS & EVENT" },
            { 2, "PROMOTION" }
        };
        #endregion

        #region Image Path Const
        public const string WEBSITE_LOGO_PATH = "/images/logos/logo.svg";
        public const string WEBSITE_FAVICON_PATH = "/images/logos/logo.svg";
        public const string WEBSITE_FOOTER_LOGO_PATH = "/images/logos/logo-footer.svg";
        public const string IMAGE_BANNER_PATH = "images/img-banner.png";
        public const string IMAGE_BANNER2_PATH = "images/img-banner-2.png";
        public const string IMAGE_BANNER3_PATH = "images/img-banner-3.png";
        public const string IMAGE_COMMON_BANNER_PATH = "/images/about-us-page/banner-about-page.png";
        #endregion
    }
}

