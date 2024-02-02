using System.ComponentModel.DataAnnotations;

namespace Entities;

public class User 
{
    [Key]
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public List<Option> Options { get; set; } = null!;
}
