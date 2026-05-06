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

        public async Task<TaskModel?> GetByIdAsync(long userId, long itemId, CancellationToken cancellationToken = default)
        {
            return await context.Tasks.FirstOrDefaultAsync(x => x.UserId == userId && x.ItemId == itemId, cancellationToken); 
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
        public async Task<List<TaskModel>> GetAllAsync(long userId, CancellationToken cancellationToken = default)
        {
            return await context.Tasks
                .Where(x => x.UserId == userId)
                .ToListAsync(cancellationToken);
        }
    }
}
