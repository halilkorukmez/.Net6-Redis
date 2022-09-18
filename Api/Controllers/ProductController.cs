using Entities.Products;
using Microsoft.AspNetCore.Mvc;
using Services.ProductDataService;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService) => _productService = productService;

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetListProductOrGetByCategoryId(Guid id) => Ok(await _productService.ProductQuery(id));

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
    {
        await _productService.AddProduct(productDto);
        return Ok();
    }
}