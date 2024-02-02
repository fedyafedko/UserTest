using UserTest.Common.DTO;
using UserTest.Common.DTO.User;

namespace UserTest.BLL.Services.Interfaces;

public interface IUserService
{
    Task<UserDTO> AddUser(CreateUserDTO dto);
}
