using StiveBack.Models;
using StiveBack.Ressources.Core;

namespace StiveBack.Ressources
{
    public class UserSaveRessource
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<int> RoleIds { get; set; }

        public UserSaveRessource()
        {
            RoleIds = new List<int>();
        }
    }
}
