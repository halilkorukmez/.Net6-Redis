using Core.BaseEntityModel;
using Entities.Products;

namespace Entities.Categories;

public class Category : BaseModel
{
    public string Name { get; set; }
    public IList<Product> Products { get; set; }
}