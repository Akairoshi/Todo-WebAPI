using DataAccess.Models;

namespace DataAccess.Data.TaskRepo
{
    public interface ITaskRepository
    {
        Task CreateAsync(TaskModel note, CancellationToken cancellationToken = default);
        Task<TaskModel?> GetByIdAsync(long userId, long itemId, CancellationToken cancellationToken = default);
        Task<TaskModel?> UpdateAsync(TaskModel note, CancellationToken cancellationToken = default);
        Task DeleteAsync(TaskModel note, CancellationToken cancellationToken = default);
        Task<List<TaskModel>> GetAllAsync(long userId, CancellationToken cancellationToken = default);
    }
}
