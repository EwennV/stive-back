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
        public IActionResult AddSupplier(SupplierRessource SupplierRessource)
        {
            var supplier = _supplierService.Add(SupplierRessource);
            return Ok(supplier);
        }

        [HttpPut]
        public IActionResult UpdateSupplier(int SupplierId, SupplierUpdateRessource SupplierRessource)
        {
            var supplier = _supplierService.Update(SupplierId, SupplierRessource);
            return Ok(supplier);
        }

        [HttpDelete]
        public IActionResult DeleteSupplier(int SupplierRessourceId)
        {
            _supplierService.Delete(SupplierRessourceId);
            return Ok();
        }
    }
}
