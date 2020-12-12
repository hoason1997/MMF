using System.ComponentModel;

 namespace MFF.DTO.Enums
{
    public enum SystemRole
    {
        [Description("Administrator")]
        Administrator = 0,
        [Description("User")]
        User = 1,
        [Description("Customer")]
        Customer = 2,
    }
    public enum Category
    {
        [Description("Event")]
        Event = 1,
        [Description("Promotion")]
        Promotion = 2
    }
}
