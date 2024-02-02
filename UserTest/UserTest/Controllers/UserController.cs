using Microsoft.AspNetCore.Mvc;
using UserTest.BLL.Services.Interfaces;
using UserTest.Common.DTO.User;

namespace UserTest.Controllers
{
    [Route("api/user")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUserDTO dto)
        {
            var user = await _userService.AddUser(dto);

            return Ok(user);
        }
    }
}
