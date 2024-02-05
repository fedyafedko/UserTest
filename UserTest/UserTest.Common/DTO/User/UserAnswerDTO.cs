namespace UserTest.Common.DTO.User;

public class UserAnswerDTO
{
    public Guid UserId { get; set; }
    public Guid TestId { get; set; }
    public List<Guid> OptionsId { get; set; } = null!;
}
