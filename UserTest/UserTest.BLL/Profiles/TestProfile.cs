using AutoMapper;
using Entities;
using UserTest.Common.DTO;

namespace UserTest.BLL.Profiles;

public class TestProfile : Profile
{
    public TestProfile()
    {
        CreateMap<Test, TestDTO>()
            .ForMember(x => x.Tasks, opt => opt.MapFrom(x => x.Tasks));

        CreateMap<TestTask, TaskTestDTO>()
            .ForMember(x => x.Options, opt => opt.MapFrom(x => x.Options));

        CreateMap<Option, OptionDTO>();
    }
}
