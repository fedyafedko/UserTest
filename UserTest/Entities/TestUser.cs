using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class TestUser
{
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(Test))]
    public Guid TestId { get; set; }
    public bool IsFinished { get; set; }
    public int Mark { get; set; }

    public User User { get; set; } = null!;
    public Test Test { get; set; } = null!;

}
