using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data.TaskRepo
{
    internal class TaskRepository(AppDbContext context) : ITaskRepository
    {
        public async Task CreateAsync(TaskModel task, CancellationToken cancellationToken = default)
        {
            await context.Tasks.AddAsync(task, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<TaskModel?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<TaskModel?> UpdateAsync(TaskModel task, CancellationToken cancellationToken = default)
        {
            await context.SaveChangesAsync(cancellationToken);
            return task;
        }
        public async Task DeleteAsync(TaskModel task, CancellationToken cancellationToken = default)
        {
            context.Tasks.Remove(task);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
