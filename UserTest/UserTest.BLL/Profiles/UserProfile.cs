using AutoMapper;
using Entities;
using UserTest.Common.DTO.User;

namespace UserTest.BLL.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDTO, User>();
        CreateMap<User, UserDTO>();
    }
}
