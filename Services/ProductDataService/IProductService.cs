using Core.GenericRepository;
using Entities.Products;

namespace Services.ProductDataService;

public interface IProductService
{
    Task<List<ProductDto>> ProductQuery(Guid ıd );
    Task AddProduct(ProductDto productDto);
}