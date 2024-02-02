using Entities;
using Microsoft.EntityFrameworkCore;

namespace UserTest.DAL.EF;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Test> Tests { get; set; } = null!;
    public DbSet<TestTask> Tasks { get; set; } = null!;
    public DbSet<Option> Options { get; set; } = null!;
    public DbSet<TestUser> UserTests { get; set; } = null!;


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasMany(u => u.Options)
            .WithMany(o => o.Users);

        builder.Entity<TestUser>()
            .HasKey(tu => new { tu.UserId, tu.TestId });
    }
}
