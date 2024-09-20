using Microsoft.AspNetCore.Identity;
using StiveBack.Database;
using StiveBack.Models;
using StiveBack.Ressources;

namespace StiveBack.Services
{
    public class UserService
    {
        private readonly MainDbContext _database;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserService()
        {
            
        }

        public UserService(MainDbContext mainDbContext)
        {
            _database = mainDbContext;
            _passwordHasher = new PasswordHasher<User>();
        }

        public List<UserRessource> GetAll()
        {
            return _database.users.ToArray().Select(user => UserToUserRessource(user)).ToList();
        }

        public UserRessource Get(int id)
        {
            var user = _database.users.FirstOrDefault(user => user.Id == id);
            return UserToUserRessource(user);
        }

        public UserRessource Add(UserSaveRessource userSaveRessource)
        {
            var user = UserSaveRessourceToUser(userSaveRessource);

            _database.users.Add(user);
            _database.SaveChanges();

            return UserToUserRessource(user);
        }

        public UserRessource Update(int id, UserSaveRessource userSaveRessource)
        {
            var user = _database.users.FirstOrDefault(user => user.Id == id);

            user.FirstName = userSaveRessource.FirstName;
            user.LastName = userSaveRessource.LastName;
            user.Email = userSaveRessource.Email;
            user.Address1 = userSaveRessource.Address1;
            user.Address2 = userSaveRessource.Address2;
            user.PostalCode = userSaveRessource.PostalCode;
            user.City = userSaveRessource.City;
            user.Password = _passwordHasher.HashPassword(user, userSaveRessource.Password);
            user.UserRole = userSaveRessource.RoleIds.Select(roleId => new UserRole
            {
                RoleId = roleId
            }).ToList();

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
                UserRole = userSaveRessource.RoleIds.Select(roleId => new UserRole
                {
                    RoleId = roleId
                }).ToList()
            };

            user.Password = _passwordHasher.HashPassword(user, userSaveRessource.Password);

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
