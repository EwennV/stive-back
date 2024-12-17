using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StiveBack.Database;
using StiveBack.Ressources;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StiveBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly string jwtKey = "MaSuperCleSecreteTresLonguePourJWT12345";
        private readonly MainDbContext _db;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthController(MainDbContext mainDbContext)
        {
            _db = mainDbContext;
            _passwordHasher = new PasswordHasher<User>();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin request)
        {
            var user = _db.users.FirstOrDefault(u => u.Email == request.Email);

            // Vérifie que l'email fourni correspond à un utilisateur en base de données
            if (null == user) {
                return Unauthorized(new { message = "Identifiants invalides" }); // Erreur floue pour ne pas donner d'indication à un attaquant sur l'origine de l'erreur
            }

            if (_passwordHasher.VerifyHashedPassword(user, user.Password, request.Password) == PasswordVerificationResult.Failed)
            {
                return Unauthorized(new { message = "Identifiants invalides" });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(jwtKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, request.Email),
                    new Claim(ClaimTypes.Role, user.IsAdmin == true ? "Admin" : "User")
                }),
                Expires = DateTime.UtcNow.AddDays(1), // La session ne durera que 24 heures / 1 jour
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { Token = tokenHandler.WriteToken(token) });
        }

    }
}
