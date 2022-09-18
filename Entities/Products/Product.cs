using Core.BaseEntityModel;
using Entities.Categories;

namespace Entities.Products;

public class Product : BaseModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}