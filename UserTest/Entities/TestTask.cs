using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class TestTask
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey(nameof(Test))]
    public Guid TestId { get; set; }
    public string Label { get; set; } = string.Empty;

    public Test Test { get; set; } = null!;
    public List<Option> Options { get; set; } = null!;
}
