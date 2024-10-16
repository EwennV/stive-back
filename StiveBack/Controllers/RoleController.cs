using Microsoft.AspNetCore.Mvc;
using StiveBack.Models;
using StiveBack.Ressources;
using StiveBack.Services;

namespace StiveBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;
        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult<List<RoleRessource>> GetAll()
        {
            List<RoleRessource> roles = _roleService.SelectAll();

            return Ok(roles);
        }

        [HttpGet("{id}")]
        public ActionResult<Role> Get(int id)
        {
            Role role = _roleService.Select(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [HttpPost]
        public ActionResult<RoleRessource?> Add([FromBody] RoleSaveRessource roleSaveRessource)
        {
            if (roleSaveRessource == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RoleRessource? savedRole = _roleService.Add(roleSaveRessource);

            return savedRole;
        }

        [HttpPut("{id}")]
        public ActionResult<RoleRessource?> Update(int id, [FromBody] RoleSaveRessource roleSaveRessource)
        {
            if (roleSaveRessource == null)
            {
                return BadRequest();
            }

            RoleRessource? updatedRole = _roleService.Update(id, roleSaveRessource);

            return updatedRole;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _roleService.Delete(id);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
    }
}
