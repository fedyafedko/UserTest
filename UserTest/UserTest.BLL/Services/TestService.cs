﻿using AutoMapper;
using Entities;
using Microsoft.EntityFrameworkCore;
using UserTest.BLL.Services.Interfaces;
using UserTest.Common.DTO;
using UserTest.DAL.Repositories.Interfaces;

namespace UserTest.BLL.Services;

public class TestService : ITestService
{
    private readonly IRepository<TestUser> _testUserRepository;
    private readonly IRepository<Test> _testRepository;
    private readonly IMapper _mapper;

    public TestService(
        IRepository<TestUser> testUserRepository,
        IRepository<Test> testRepository,
        IMapper mapper)
    {
        _testUserRepository = testUserRepository;
        _testRepository = testRepository;
        _mapper = mapper;
    }

    public async Task<List<TestDTO>> GetTestsForUser(Guid userId)
    {
        var tests = await _testUserRepository.Where(x => x.User.Id == userId).Select(x => x.Test).ToListAsync();

        var dto = _mapper.Map<List<TestDTO>>(tests);

        foreach (var item in dto)
        {
            var userTest = await _testUserRepository.FirstOrDefaultAsync(x => x.UserId == userId && x.TestId == item.Id)
                ?? throw new Exception("Test not found");

            item.IsFinished = userTest.IsFinished;
        }

        return dto;
    }

    public async Task<TestDTO> GetTestById(Guid testId)
    {
        var test = await _testRepository
                .Include(x => x.Tasks)
                .ThenInclude(x => x.Options)
                .FirstOrDefaultAsync(x => x.Id == testId);

        return _mapper.Map<TestDTO>(test);
    }
}
