using Core.GenericRepository;
using Entities.Categories;
using Entities.Products;
using Entities.Users;

namespace DataAccess.CoreUnitOfWork;

public interface IUnitOfWork : IAsyncDisposable
{
    IBaseRepository<Product> Product { get; }
    IBaseRepository<Category> Category { get; }
    IBaseRepository<User> User { get; }
    Task<int> SaveAsync();
}
