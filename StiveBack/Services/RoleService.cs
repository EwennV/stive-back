using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StiveBack.Database;
using StiveBack.Models;
using StiveBack.Ressources;

namespace StiveBack.Services
{
    public class RoleService
    {
        private readonly MainDbContext _database;
        public RoleService(MainDbContext mainDbContext)
        {
            _database = mainDbContext;
        }

        public List<RoleRessource> SelectAll()
        {
            List<RoleRessource> roles = _database.roles.ToList().Select(role => RoleToRoleRessource(role)).ToList();

            return roles;
        }

        public Role? Select(int id)
        {
            Role? role = _database.roles.FirstOrDefault(role => role.Id == id);

            if (role == null)
            {
                return null;
            }

            return role;
        }

        public RoleRessource? Add(RoleSaveRessource roleSaveRessource)
        {
            Role role = RoleSaveRessourceToRole(roleSaveRessource);

            _database.roles.Add(role);
            _database.SaveChanges();

            return RoleToRoleRessource(role);
        }

        public RoleRessource? Update(int id, RoleSaveRessource roleSaveRessource)
        {
            Role? role = _database.roles.FirstOrDefault(role => role.Id == id);

            if (role == null)
            {
                throw new Exception("Role not found");
            }

            role.Name = roleSaveRessource.Name ?? role.Name;

            _database.SaveChanges();

            return RoleToRoleRessource(role);
        }

        public void Delete(int id)
        {
            Role? role = _database.roles.FirstOrDefault(role => role.Id == id);

            if (role == null)
            {
                throw new Exception("Role not found");
            }

            _database.roles.Remove(role);
            _database.SaveChanges();
        }

        public RoleRessource RoleToRoleRessource(Role role)
        {
            RoleRessource roleRessource = new RoleRessource
            {
                Id = role.Id,
                Name = role.Name,
            };

            return roleRessource;
        }

        public Role RoleSaveRessourceToRole(RoleSaveRessource roleSaveRessource)
        {
            Role role = new Role
            {
                Name = roleSaveRessource.Name,
            };

            return role;
        }

    }
}
