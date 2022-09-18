using AutoMapper;
using Core.GenericRepository;
using DataAccess.CoreUnitOfWork;
using Entities.Products;
using Services.AutoMapper;

namespace Services.ProductDataService;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ProductService(IUnitOfWork unitOfWork)
    {
        _mapper = BaseMappingConfig.GetConfig();
        _unitOfWork = unitOfWork;
    }

    // getListProduct , getProductByCategoryId , getProduct 
    public async Task<List<ProductDto>> ProductQuery(Guid ıd) =>
        _mapper.Map<List<ProductDto>>(
            await _unitOfWork.Product.GetListAsync(
                x=> ıd == Guid.Empty && x.IsActive 
                    || x.CategoryId == ıd && x.IsActive 
                    || x.Id == ıd && x.IsActive ));

    public async Task AddProduct(ProductDto productDto) =>
        await _unitOfWork.Product.AddAsync(
                _mapper.Map<Product>(productDto))
            .ContinueWith(t => _unitOfWork.SaveAsync());
}