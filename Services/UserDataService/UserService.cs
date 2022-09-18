using AutoMapper;
using DataAccess.CoreUnitOfWork;
using Entities.Baskets;
using Entities.Users;
using Services.AutoMapper;
using Services.BasketDataService;

namespace Services.UserDataService;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IBasketService _basketService;
    public UserService(IUnitOfWork unitOfWork, IBasketService basketService)
    {
        _mapper = BaseMappingConfig.GetConfig();
        _unitOfWork = unitOfWork;
        _basketService = basketService;
    }
    public async Task<List<UserDto>> UserGetQuery(Guid ıd) =>
        _mapper.Map<List<UserDto>>(
            await _unitOfWork.User.GetListAsync(
                x=> ıd == Guid.Empty && x.IsActive 
                    || x.Id == ıd && x.IsActive ));

    public async Task CreateUser(UserDto userDto)
    {
        var result = await _unitOfWork.User.AddAsync(
                _mapper.Map<User>(userDto))
            .ContinueWith(t => _unitOfWork.SaveAsync());
        if (result.IsCompleted) await _basketService.CreateBasket(new Basket {UserId = userDto.Id});
    }
}
