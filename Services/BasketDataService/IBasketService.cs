using Entities.Baskets;
namespace Services.BasketDataService;

public interface IBasketService
{
    Task<bool> CreateBasket(Basket basketDto);
    Task<Basket> GetBasket(string userId);
    Task<Basket> UpdateBasket(Basket basketDto);
    

}