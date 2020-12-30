namespace MFF.Infrastructure.Models
{
    public class UserItemModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public bool IsSystemAccount { get; set; }
        public string FullName => string.IsNullOrEmpty(MiddleName) ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleName} {LastName}";
        public string RoleCombine { get; set; }
    }
}
