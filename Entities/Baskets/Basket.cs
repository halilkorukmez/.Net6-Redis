using Core.BaseEntityModel;
using Entities.BasketItems;
using Entities.Users;

namespace Entities.Baskets;

public class Basket : BaseModel
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    public decimal TotalCount 
    { get
        {
            decimal totalprice = 0;
            foreach (var item in Items)
            {
                totalprice += item.Price ;
            }
            return totalprice;
        }
    }
}