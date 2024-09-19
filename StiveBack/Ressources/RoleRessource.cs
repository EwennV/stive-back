using StiveBack.Ressources.Core;
using System.Runtime.CompilerServices;

namespace StiveBack.Ressources
{
    public class RoleRessource : EntityRessource
    {
        public string Name { get; set; }
        public List<UserRessource> Users { get; set; }

        public RoleRessource()
        { 
            Users = new List<UserRessource>();
        }
        public RoleRessource(List<UserRessource> users): this()
        {
            Users = users;
        }
    }
}
