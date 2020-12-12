using System.ComponentModel.DataAnnotations;

namespace MFF.DTO.Enums
{
    public enum Permissions : short
    {
        [Display(GroupName = "Dashboard", Name = "View", Description = "Can view dashboard")]
        DashboardView,

        [Display(GroupName = "Post", Name = "Add", Description = "Can add new post")]
        PostAdd,
        [Display(GroupName = "Post", Name = "Update", Description = "Can edit an existing post")]
        PostUpdate,
        [Display(GroupName = "Post", Name = "Delete", Description = "Can delete an existing post")]
        PostDelete,
        [Display(GroupName = "Post", Name = "View", Description = "Can view post")]
        PostView,

        [Display(GroupName = "User", Name = "Add", Description = "Can add new user")]
        UserAdd,
        [Display(GroupName = "User", Name = "Update", Description = "Can edit an existing user")]
        UserUpdate,
        [Display(GroupName = "User", Name = "Delete", Description = "Can delete an existing user")]
        UserDelete,
        [Display(GroupName = "User", Name = "View", Description = "Can view user")]
        UserView,

        [Display(GroupName = "Contact", Name = "View", Description = "Can view contact")]
        ContactView,

        [Display(GroupName = "Feedback", Name = "View", Description = "Can view feedback")]
        FeedbackView,
        [Display(GroupName = "Feedback", Name = "Publish", Description = "Can view feedback")]
        FeedbackPublish,

        [Display(GroupName = "Product", Name = "View", Description = "Can view Product")]
        ProductView,
        [Display(GroupName = "Product", Name = "Publish", Description = "Can view Product")]
        ProductPublish,
        [Display(GroupName = "Product", Name = "Add", Description = "Can add Product")]
        ProductAdd,
        [Display(GroupName = "Product", Name = "Update", Description = "Can update Product")]
        ProductUpdate,


        [Display(GroupName = "Setting", Name = "View", Description = "Can add new setting")]
        SettingView,
        [Display(GroupName = "Setting", Name = "Update", Description = "Can edit an existing setting")]
        SettingUpdate,
    }
}
