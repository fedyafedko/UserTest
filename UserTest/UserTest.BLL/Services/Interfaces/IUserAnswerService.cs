using UserTest.Common.DTO.User;

namespace UserTest.BLL.Services.Interfaces;

public interface IUserAnswerService
{
    Task<bool> AddUserAnswer(UserAnswerDTO dto);
}
