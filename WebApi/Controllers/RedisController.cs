using Core.Redis.Cache;
using Entities.Categories;
using Entities.Products;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RedisController : ControllerBase
{
    private readonly ICacheService _cacheService;
    public RedisController(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Get(string key)
    {
        return Ok(await _cacheService.Get<Product>(key));
    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetCategory(string key)
    {
        return Ok(await _cacheService.Get<Category>(key));
    }
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> AddOrUpdate([FromBody] Product product)
    {
        return Ok(await _cacheService.AddOrUpdate(product.Name, product));
    }
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> AddOrUpdateCat([FromBody] Category category)
    {
        return Ok(await _cacheService.AddOrUpdate(category.Name, category));
    }
    [HttpDelete]
    [Route("[action]")]
    public async Task<IActionResult> Remove(string key)
    {
        return Ok(await _cacheService.Remove(key));
    }


}