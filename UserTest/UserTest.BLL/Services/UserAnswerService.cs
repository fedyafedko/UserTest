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
        var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == dto.UsersId)
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

        int count = 0;

        foreach (var item in user.Options)
        {
            if (item.IsCorrect)
            {
                count++;
            }
        }
        var test = await _testRepository.Include(x => x.Tasks).FirstOrDefaultAsync(x => x.Id == testId)
            ?? throw new Exception("Test not found");

        test.Tasks.Count();

        userTest.Mark = count / test.Tasks.Count() * test.MaxMark;
        userTest.IsFinished = true;
        return await _testUserRepository.UpdateAsync(userTest);
    }
}
