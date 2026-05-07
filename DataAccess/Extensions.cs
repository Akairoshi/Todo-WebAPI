using DataAccess.Data.NoteRepo;
using DataAccess.Data.TaskRepo;
using DataAccess.Data.UserRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AppDbContext = DataAccess.Data.AppDbContext;

namespace DataAccess
{
    public static class Extensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection servicesCollection, IConfiguration configuration)
        {
            var db = configuration.GetSection("DatabaseConfiguration");
            var connectionString = $"Host={db["Host"]};Database={db["Database"]};Username={db["Username"]};Password={db["Password"]}";

            servicesCollection.AddScoped<INoteRepository, NoteRepository>();
            servicesCollection.AddScoped<ITaskRepository, TaskRepository>();
            servicesCollection.AddScoped<IUserRepository, UserRepository>();
            servicesCollection.AddDbContext<AppDbContext>(x =>
            {
                x.UseNpgsql(connectionString);
            });
            return servicesCollection;
        }
        public static async Task CheckDatabaseConnectionAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<AppDbContext>>();
            
            logger.LogInformation("Checking database connection... ");

            try
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await db.Database.ExecuteSqlRawAsync("SELECT 1");
                logger.LogInformation("Database connection successful");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Database connection failed");
            }
        }
    }
}
