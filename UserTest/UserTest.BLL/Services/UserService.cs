using AutoMapper;
using Entities;
using Microsoft.EntityFrameworkCore;
using UserTest.BLL.Services.Interfaces;
using UserTest.Common.DTO.User;
using UserTest.DAL.Repositories.Interfaces;

namespace UserTest.BLL.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public UserService(
        IRepository<User> userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDTO> AddUser(CreateUserDTO dto)
    {
        var user = await _userRepository.FirstOrDefaultAsync(x => x.Email == dto.Email);

        if (user != null)
        {
            return _mapper.Map<UserDTO>(user);
        }
        else
        {
            user = _mapper.Map<User>(dto);

            await _userRepository.InsertAsync(user);

            return _mapper.Map<UserDTO>(user);
        }
    }
}
