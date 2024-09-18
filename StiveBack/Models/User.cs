namespace StiveBack.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //[ForeignKey("RoleId")]
        //public int RoleId { get; set; }
        //public Role Role { get; set; }
        public List<UserRole> UserRole { get; set; }
        public User()
        {
            UserRole = new List<UserRole>();
        }
    }
}