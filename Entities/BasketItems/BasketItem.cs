using Entities.Products;

namespace Entities.BasketItems;

public class BasketItem
{
    public Guid ProductId { get; set; }
    public bool IsActive { get; set; }
    
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
}