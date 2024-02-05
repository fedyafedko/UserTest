using AutoMapper;
using Entities;
using Microsoft.EntityFrameworkCore;
using UserTest.BLL.Services.Interfaces;
using UserTest.Common.DTO.User;
using UserTest.DAL.Repositories.Interfaces;

namespace UserTest.BLL.Services;

public class UserAnswerService : IUserAnswerService
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<TestUser> _testUserRepository;
    private readonly IRepository<Test> _testRepository;
    private readonly IRepository<Option> _optionRepository;

    public UserAnswerService(
        IRepository<User> userRepository,
        IRepository<TestUser> testUserRepository,
        IRepository<Test> testRepository,
        IRepository<Option> optionRepository)
    {
        _userRepository = userRepository;
        _testUserRepository = testUserRepository;
        _testRepository = testRepository;
        _optionRepository = optionRepository;
    }
    public async Task<bool> AddUserAnswer(UserAnswerDTO dto)
    {
        var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == dto.UserId)
            ?? throw new Exception("User not found");

        var userTest = await _testUserRepository.FirstOrDefaultAsync(x => x.UserId == user.Id && x.TestId == dto.TestId)
            ?? throw new Exception("Test not found");

        userTest.IsFinished = true;

        user.Options = new List<Option>();

        foreach (var item in dto.OptionsId)
        {
            var option = await _optionRepository.FirstOrDefaultAsync(x => x.Id == item)
                ?? throw new Exception("Option not found");

            user.Options.Add(option);
        }

        await _userRepository.UpdateAsync(user);

        return await CheckUserTest(user.Id, dto.TestId);
    }

    private async Task<bool> CheckUserTest(Guid userId, Guid testId)
    {
        var userTest = await _testUserRepository.FirstOrDefaultAsync(x => x.UserId == userId && x.TestId == testId)
            ?? throw new Exception("Test not found");

        var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == userId)
            ?? throw new Exception("User not found");

        int correctCount = user.Options.Count(item => item.IsCorrect == true);

        var test = await _testRepository.Include(x => x.Tasks).FirstOrDefaultAsync(x => x.Id == testId)
            ?? throw new Exception("Test not found");

        int totalTasks = test.Tasks.Count();

        if (totalTasks == 0)
            throw new Exception("Test has no tasks");

        int mark = (int)((double)correctCount / totalTasks * test.MaxMark);

        userTest.Mark = mark;
        userTest.IsFinished = true;
        return await _testUserRepository.UpdateAsync(userTest);
    }

}
