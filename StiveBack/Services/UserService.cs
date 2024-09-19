using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StiveBack.Database;
using StiveBack.Models;
using StiveBack.Ressources;

namespace StiveBack.Services
{
    public class UserService
    {
        private MainDbContext _database;

        public UserService()
        {
            
        }

        public UserService(MainDbContext mainDbContext)
        {
            _database = mainDbContext;
        }

        public UserRessource Add(UserSaveRessource userSaveRessource)
        {
            var user = UserSaveRessourceToUser(userSaveRessource);

            _database.users.Add(user);
            _database.SaveChanges();

            return UserToUserRessource(user);
        }

        private User UserSaveRessourceToUser(UserSaveRessource userSaveRessource)
        {
            var user = new User
            {
                FirstName = userSaveRessource.FirstName,
                LastName = userSaveRessource.LastName,
                Email = userSaveRessource.Email,
                Address1 = userSaveRessource.Address1,
                Address2 = userSaveRessource.Address2,
                PostalCode = userSaveRessource.PostalCode,
                City = userSaveRessource.City,
                Password = userSaveRessource.Password,
                UserRole = userSaveRessource.RoleIds.Select(roleId => new UserRole
                {
                    RoleId = roleId
                }).ToList()
            };

            return user;
        }

        private UserRessource UserToUserRessource(User user)
        {
            var userRessource = new UserRessource
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address1 = user.Address1,
                Address2 = user.Address2,
                PostalCode = user.PostalCode,
                City = user.City,
                Roles = user.UserRole
                .Select(c => new RoleRessource { Id = c.Role.Id, Name = c.Role.Name })
                .ToList()
            };

            return userRessource;
        }
    }
}
