using StiveBack.Ressources.Core;

namespace StiveBack.Ressources
{
    public class UserRessource : EntityRessource
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
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
