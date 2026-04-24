using DataAccess.Models;

namespace DataAccess.Data.TaskRepo
{
    public interface ITaskRepository
    {
        Task CreateAsync(TaskModel note, CancellationToken cancellationToken = default);
        Task<TaskModel?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<TaskModel?> UpdateAsync(TaskModel note, CancellationToken cancellationToken = default);
        Task DeleteAsync(TaskModel note, CancellationToken cancellationToken = default);
    }
}
