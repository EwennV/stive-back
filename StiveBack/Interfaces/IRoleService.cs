using StiveBack.Models;

namespace StiveBack.Interfaces
{
    public interface IRoleService
    {
        List<Role> GetAllRoles();
        Role GetRole(int id);
        Role AddRole(Role role);
        Role UpdateRole(int id, Role role);
        void DeleteRole(int id);
    }
}
