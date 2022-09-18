using Core.Redis.Cache;
using DataAccess.CoreUnitOfWork;
using Entities.Baskets;
using Newtonsoft.Json;

namespace Services.BasketDataService;

public class BasketService : IBasketService
{
    private readonly ICacheService _cacheService;
    public BasketService(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }
    public async Task<bool> CreateBasket(Basket basketDto) => await _cacheService.AddOrUpdate(basketDto.UserId.ToString(), basketDto);

    public async Task<Basket> GetBasket(string userName) => await _cacheService.Get<Basket>(userName);

    public async Task<Basket> UpdateBasket(Basket basket)
    {
        await _cacheService.AddOrUpdate(basket.User.UserName, JsonConvert.SerializeObject(basket));
        return await GetBasket(basket.User.UserName);
    }
}