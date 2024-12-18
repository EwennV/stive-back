using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StiveBack.Models;
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
        [Authorize(Roles = "Admin")]
        public IActionResult AddProduct(ProductSaveRessource ProductSaveRessource)
        {
            ProductRessource? product;
            try
            {
                product = _productService.Add(ProductSaveRessource);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
            return Ok(product);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateProduct(int ProductId, ProductSaveRessource ProductSaveRessource)
        {
            ProductRessource product;
            try
            {
                product = _productService.Update(ProductId, ProductSaveRessource);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
            return Ok(product);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProduct(int ProductRessource)
        {
            _productService.Delete(ProductRessource);
            return Ok();
        }
    }
}
