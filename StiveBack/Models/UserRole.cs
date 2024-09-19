using StiveBack.Models.Core;

namespace StiveBack.Models
{
    public class UserRole: Entity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }

        public UserRole() { }
    }
}
