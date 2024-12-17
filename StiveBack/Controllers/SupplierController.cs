using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StiveBack.Ressources;
using StiveBack.Services;

namespace StiveBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private SupplierService _supplierService { get; set; }

        public SupplierController(SupplierService SupplierService)
        {
            _supplierService = SupplierService;
        }

        [HttpGet("{id}")]
        public IActionResult Select(int id)
        {
            var supplier = _supplierService.Select(id);
            return Ok(supplier);
        }

        [HttpGet]
        public IActionResult SelectAll()
        {
            var suppliers = _supplierService.SelectAll();
            return Ok(suppliers);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddSupplier(SupplierUpdateRessource SupplierUpdateRessource)
        {
            var supplier = _supplierService.Add(SupplierUpdateRessource);
            return Ok(supplier);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateSupplier(int SupplierId, SupplierUpdateRessource SupplierRessource)
        {
            var supplier = _supplierService.Update(SupplierId, SupplierRessource);
            return Ok(supplier);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteSupplier(int SupplierRessourceId)
        {
            _supplierService.Delete(SupplierRessourceId);
            return Ok();
        }
    }
}
