using DataAccess.Models;

namespace BussinesLogic.Services.TaskService
{
    public interface ITaskService
    {
        Task CreateAsync(string name, string? description = null,
                    CancellationToken cancellationToken = default);
        Task<TaskModel> GetByIdAsync(int id, CancellationToken cancellation = default);
        Task PatchByIdAsync(int id, string? name = null,
                    string? description = null, TaskProgressStauts? status = null,
                    CancellationToken cancellationToken = default);
        Task UpdateByIdAsync(int id, string name,
                    string description, TaskProgressStauts status,
                    CancellationToken cancellationToken = default);
        Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
