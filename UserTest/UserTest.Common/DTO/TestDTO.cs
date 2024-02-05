namespace UserTest.Common.DTO;

public class TestDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int MaxMark { get; set; }
    public bool IsFinished { get; set; }
    public List<TaskTestDTO> Tasks { get; set; } = null!;
}