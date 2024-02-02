using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Option
{
    [Key]
    public Guid Id { get; set; }

    public string Label { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }

    [ForeignKey(nameof(Task))]
    public Guid TaskId { get; set; }

    public TestTask Task { get; set; } = null!;
    public List<User> Users { get; set; } = null!;
}
