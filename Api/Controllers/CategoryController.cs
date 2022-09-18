using Entities.Categories;
using Microsoft.AspNetCore.Mvc;
using Services.CategoryDataService;

namespace Api.Controllers;

public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> AddProduct([FromBody] CategoryDto categoryDto)
    {
        await _categoryService.AddCategory(categoryDto);
        return Ok();
    }
}