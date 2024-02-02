using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Test
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int MaxMark { get; set; }

    public List<TestTask> Tasks { get; set; } = null!;

}
