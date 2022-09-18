using Entities.Users;

namespace Services.UserDataService;

public interface IUserService
{
    Task<List<UserDto>> UserGetQuery(Guid ıd);
    Task CreateUser(UserDto userDto);
}