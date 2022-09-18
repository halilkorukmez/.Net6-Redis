using Core.GenericRepository;
using DataAccess.DataContext;
using Entities.Categories;
using Entities.Products;
using Entities.Users;

namespace DataAccess.CoreUnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProjectDbContext _context;
    private BaseRepository<Product> _product;
    private BaseRepository<Category> _category;
    private BaseRepository<User> _user;
    public UnitOfWork(ProjectDbContext context) => _context = context;
    public async ValueTask DisposeAsync() => await _context.DisposeAsync();
    public IBaseRepository<Product> Product => _product ?? new BaseRepository<Product>(_context);
    public IBaseRepository<Category> Category => _category ?? new BaseRepository<Category>(_context);
    public IBaseRepository<User> User => _user ?? new BaseRepository<User>(_context);
    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
}