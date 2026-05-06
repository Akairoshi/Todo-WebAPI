using DataAccess.Models;

namespace BussinesLogic.Services.TaskService
{
    public interface ITaskService
    {
        Task CreateAsync(long userId, string name, string? description = null,
                    CancellationToken cancellationToken = default);
        Task<TaskModel> GetByIdAsync(long userId, long itemId, CancellationToken cancellation = default);
        Task PatchByIdAsync(long userId, long itemId, string? name = null,
                    string? description = null, TaskProgressStauts? status = null,
                    CancellationToken cancellationToken = default);
        Task UpdateByIdAsync(long userId, long itemId, string name,
                    string description, TaskProgressStauts status,
                    CancellationToken cancellationToken = default);
        Task DeleteByIdAsync(long userId, long itemId, CancellationToken cancellationToken = default);
        Task<List<TaskModel>> GetAllAsync(long userId, CancellationToken cancellationToken = default);
    }
}
