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
            // Exemple utilisateur existant (à remplacer par ton système existant)
            var user = _db.users.FirstOrDefault(u => u.Email == request.Email);

            if (null == user) {
                return Unauthorized(new { message = "Identifiants invalides" });
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
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { Token = tokenHandler.WriteToken(token) });
        }

    }
}
