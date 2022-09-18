using Entities.Users;
using Microsoft.AspNetCore.Mvc;
using Services.UserDataService;

namespace Api.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> UserGetQuery(Guid id) => Ok(await _userService.UserGetQuery(id));

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> AddProduct([FromBody] UserDto userDto)
    {
        await _userService.CreateUser(userDto);
        return Ok();
    }
}