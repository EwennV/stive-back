using Microsoft.AspNetCore.Mvc;
using StiveBack.Services;

namespace StiveBack.Controllers
{
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

    }
}
