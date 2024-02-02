namespace UserTest.Common.DTO;

public class TaskTestDTO
{
    public Guid Id { get; set; }
    public Guid TestId { get; set; }
    public string Label { get; set; } = string.Empty;
    public List<OptionDTO> Options { get; set; } = null!;
}
