using Microsoft.EntityFrameworkCore;
using UserTest.DAL.EF;

namespace UserTest.Extensions
{
    public static class ServiceExtensions
    {
        public static void MigrateDatabase(this IHost app)
        {
            using var serviceScope = app.Services.CreateScope();

            var services = serviceScope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }
    }
}
