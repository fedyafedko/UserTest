using Microsoft.AspNetCore.Mvc;
using UserTest.BLL.Services.Interfaces;
using UserTest.Common.DTO.User;

namespace UserTest.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IUserAnswerService _userAnswerService;
        public TestController(ITestService testService, IUserAnswerService userAnswerService)
        {
            _testService = testService;
            _userAnswerService = userAnswerService;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetTestsForUser(Guid userId)
        {
            var tests = await _testService.GetTestsForUser(userId);

            return Ok(tests);
        }

        [HttpGet("{testId}")]
        public async Task<IActionResult> GetTestById(Guid testId)
        {
            var test = await _testService.GetTestById(testId);

            return Ok(test);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddUserAnswer(UserAnswerDTO dto)
        {
            var option = await _userAnswerService.AddUserAnswer(dto);

            return Ok(option);
        }
    }
}
