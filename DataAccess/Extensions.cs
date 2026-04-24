using DataAccess.Data.NoteRepo;
using DataAccess.Data.TaskRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using AppDbContext = DataAccess.Data.AppDbContext;

namespace DataAccess
{
    public static class Extensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped<INoteRepository, NoteRepository>();
            servicesCollection.AddScoped<ITaskRepository, TaskRepository>();
            servicesCollection.AddDbContext<AppDbContext>(x =>
            {
                x.UseNpgsql("Host=localhost;Database=NoteDb;Username=postgres;Password=080907");
            });
            return servicesCollection;
        }
    }
}
