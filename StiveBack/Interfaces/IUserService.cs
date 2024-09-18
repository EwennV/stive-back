using StiveBack.Ressources;
namespace StiveBack.Interfaces
{
    public interface IUserService
    {
        List<UserRessource> GetAllUsers();
        UserRessource AddUser(UserSaveRessource userRessource);
        UserRessource GetUser(int id);
        UserRessource UpdateUser(int id, UserSaveRessource user);
        void DeleteUser(int id);
    }
}
