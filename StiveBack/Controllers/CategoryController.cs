using Microsoft.AspNetCore.Mvc;
using StiveBack.Ressources;
using StiveBack.Services;

namespace StiveBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController: ControllerBase
    {
        private CategoryService _categoryService { get; set; }

        public CategoryController(CategoryService CategoryService)
        {
            _categoryService = CategoryService;
        }

        [HttpGet("{id}")]
        public IActionResult Select(int id)
        {
            var category = _categoryService.Select(id);
            return Ok(category);
        }

        [HttpGet]
        public IActionResult SelectAll()
        {
            var categories = _categoryService.SelectAll();
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult AddCategory(CategorySaveRessource CategorySaveRessource)
        {
            var category = _categoryService.Add(CategorySaveRessource);

            return Ok(category);
        }

        [HttpPut]
        public IActionResult UpdateCategory(int CategoryId, CategorySaveRessource CategoryRessource)
        {
            var category = _categoryService.Update(CategoryId, CategoryRessource);
            return Ok(category);
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int CategoryRessourceId)
        {
            _categoryService.Delete(CategoryRessourceId);
            return Ok();
        }
    }
}
