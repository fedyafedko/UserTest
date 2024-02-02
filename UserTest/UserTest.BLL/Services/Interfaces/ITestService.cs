using UserTest.Common.DTO;

namespace UserTest.BLL.Services.Interfaces;

public interface ITestService
{
    Task<List<TestDTO>> GetTestsForUser(Guid userId);
    Task<TestDTO> GetTestById(Guid testId);
}
