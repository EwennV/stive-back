using StiveBack.Models.Core;


namespace StiveBack.Models
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public List<UserRole> UserRole { get; set; }
        public User() { }
    }
}