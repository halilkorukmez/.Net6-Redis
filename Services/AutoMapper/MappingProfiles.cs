using AutoMapper;
using Entities.Categories;
using Entities.Products;
using Entities.Users;

namespace Services.AutoMapper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>();
        CreateMap<Category,CategoryDto>();
        CreateMap<CategoryDto,Category>();
        CreateMap<User,UserDto>();
        CreateMap<UserDto, User>();
    }
}