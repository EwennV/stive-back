using StiveBack.Ressources.Core;

namespace StiveBack.Ressources
{
    public class UserRessource : EntityRessource
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<RoleRessource> Roles { get; set; }

        public UserRessource()
        {
            Roles = new List<RoleRessource>();
        }
        public UserRessource(List<RoleRessource> roles)
        {
            Roles = roles;
        }
    }
}
