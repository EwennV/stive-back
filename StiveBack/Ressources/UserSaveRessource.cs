using StiveBack.Models;
using StiveBack.Ressources.Core;
using System.ComponentModel.DataAnnotations;

namespace StiveBack.Ressources
{
    public class UserSaveRessource
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string Password { get; set; }
        public bool? IsAdmin { get; set; }
        public List<int> RoleIds { get; set; }

        public UserSaveRessource()
        {
            RoleIds = new List<int>();
        }
    }
}
