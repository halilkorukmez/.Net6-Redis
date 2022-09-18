using System.Linq.Expressions;
using Entities.Categories;

namespace Services.CategoryDataService;

public interface ICategoryService
{
    Task<List<CategoryDto>> CategoryQuery(Guid ıd);
    Task AddCategory(CategoryDto categoryDto);

}