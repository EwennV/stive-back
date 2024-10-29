using Microsoft.AspNetCore.Mvc;
using StiveBack.Ressources;
using StiveBack.Services;

namespace StiveBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController: ControllerBase
    {
        private ProductService _productService { get; set; }

        public ProductController(ProductService ProductService)
        {
            _productService = ProductService;
        }

        [HttpGet("Get/{id}")]
        public IActionResult Select(int id)
        {
            var product = _productService.Select(id);
            return Ok(product);
        }

        [HttpGet]
        public IActionResult SelectAll()
        {
            var products = _productService.SelectAll();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductSaveRessource ProductSaveRessource)
        {
            var product = _productService.Add(ProductSaveRessource);
            return Ok(product);
        }

        [HttpPut]
        public IActionResult UpdateProduct(int ProductId, ProductSaveRessource ProductSaveRessource)
        {
            var product = _productService.Update(ProductId, ProductSaveRessource);
            return Ok(product);
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int ProductRessource)
        {
            _productService.Delete(ProductRessource);
            return Ok();
        }

    }
}
