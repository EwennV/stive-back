using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StiveBack.Ressources;
using StiveBack.Services;

namespace StiveBack.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<UserRessource>> GetAll()
        {
            return _userService.SelectAll();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<UserRessource> Get(int id)
        {
            var user = _userService.Select(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<UserRessource> AddUser([FromBody] UserSaveRessource user)
        {
            var userRessource = _userService.Add(user);

            return Ok(userRessource);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<UserRessource> UpdateUser(int id, [FromBody] UserUpdateRessource user)
        {
            try
            {
                UserRessource updatedUser = _userService.Update(id, user);
                return updatedUser;
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                _userService.Delete(id);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
