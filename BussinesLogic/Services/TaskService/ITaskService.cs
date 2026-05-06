using BussinesLogic.Dtos;
using DataAccess.Models;

namespace BussinesLogic.Services.TaskService
{
    public interface ITaskService
    {
        Task CreateAsync(long userId, CreateTaskDto dto,
                    CancellationToken cancellationToken = default);
        Task<TaskModel> GetByIdAsync(long userId, long itemId, CancellationToken cancellation = default);
        Task PatchByIdAsync(long userId, long itemId, PatchTaskDto dto,
                    CancellationToken cancellationToken = default);
        Task UpdateByIdAsync(long userId, long itemId, UpdateTaskDto dto,
                    CancellationToken cancellationToken = default);
        Task DeleteByIdAsync(long userId, long itemId, CancellationToken cancellationToken = default);
        Task<List<TaskModel>> GetAllAsync(long userId, CancellationToken cancellationToken = default);
    }
}
