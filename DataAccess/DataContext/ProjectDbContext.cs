using Entities.Categories;
using Entities.Products;
using Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataContext;

public class ProjectDbContext : DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
}