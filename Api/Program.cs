using Core.GenericRepository;
using Core.Redis.Cache;
using Core.Redis.Configurations;
using DataAccess.CoreUnitOfWork;
using DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Services.BasketDataService;
using Services.CategoryDataService;
using Services.ProductDataService;
using Services.UserDataService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICacheService, CacheService>();
builder.Services.AddSingleton<IRedisConnectionFactory, RedisConnectionFactory>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddDbContextPool<ProjectDbContext>(options => options
    .UseNpgsql(builder.Configuration.GetConnectionString("TestConnectionString"))
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();  

app.UseAuthorization();

app.MapControllers();

app.Run();