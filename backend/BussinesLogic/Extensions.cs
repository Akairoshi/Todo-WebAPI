using BussinesLogic.Services.NoteService;
using BussinesLogic.Services.TaskService;
using Microsoft.Extensions.DependencyInjection;

namespace BussinesLogic
{
    public static class Extensions
    {
        public static IServiceCollection AddBusinesLogic(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped<INoteService, NoteService>();
            servicesCollection.AddScoped<ITaskService, TaskService>();
            return servicesCollection;
        }
    }
}
