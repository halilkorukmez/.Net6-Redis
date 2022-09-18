using Entities.Baskets;
using Microsoft.AspNetCore.Mvc;
using Services.BasketDataService;

namespace Api.Controllers;
[ApiController]
[Route("[controller]")]
public class BasketController : ControllerBase
{
    private readonly IBasketService _basketService;

    public BasketController(IBasketService basketService)
    {
        _basketService = basketService;
    }
    
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetBasket(string basketId)
    {
        return Ok(await _basketService.GetBasket(basketId));
    }
    
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> AddOrUpdateBasket([FromBody] Basket basketDto)
    {
        return Ok(await _basketService.CreateBasket(basketDto));
    }
    
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> AddOrUpdateUserBasket([FromBody] Basket basketItemDto)
    {
        return Ok(await _basketService.UpdateBasket(basketItemDto));
    }
}