using StiveBack.Models.Core;

namespace StiveBack.Models
{

    public class Role : Entity
    { 
        public string Name { get; set; }
        public List<UserRole> UserRole { get; set; }

        public Role()
        {
            UserRole = new List<UserRole>();
        }
    }
}
