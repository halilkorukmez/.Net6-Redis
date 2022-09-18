using AutoMapper;
using Core.GenericRepository;
using DataAccess.CoreUnitOfWork;
using Entities.Categories;
using Services.AutoMapper;

namespace Services.CategoryDataService;

public class CategoryService : ICategoryService
{   
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CategoryService(IUnitOfWork unitOfWork)
    {
        _mapper = BaseMappingConfig.GetConfig();
        _unitOfWork = unitOfWork;
    }

    public async Task<List<CategoryDto>> GetOrGetListCategory(Guid ıd) =>
        _mapper.Map<List<CategoryDto>>(
            await _unitOfWork.Category.GetListAsync(
                x=> ıd == Guid.Empty && x.IsActive 
                    || x.Id == ıd && x.IsActive ));

    public async Task AddCategory(CategoryDto categoryDto) =>
        await _unitOfWork.Category.AddAsync(
                _mapper.Map<Category>(categoryDto))
            .ContinueWith(t => _unitOfWork.SaveAsync());
}