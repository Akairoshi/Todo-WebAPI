using DataAccess.Data.NoteRepo;
using DataAccess.Data.TaskRepo;
using DataAccess.Models;

namespace BussinesLogic.Services.TaskService
{
    internal class TaskService(ITaskRepository taskRepository) : ITaskService
    {
        public async Task CreateAsync(long userId, string name, string? description = null, 
            CancellationToken cancellationToken = default)
        {
            var task = new TaskModel()
            {
                UserId = userId,
                Name = name,
                Description = description,
                Status = TaskProgressStauts.NotStarted,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };

            await taskRepository.CreateAsync(task, cancellationToken);
        }

        public async Task DeleteByIdAsync(long userId, long itemId, CancellationToken cancellationToken = default)
        {
            var task = await taskRepository.GetByIdAsync(userId, itemId, cancellationToken);

            if (task == null)
                throw new Exception("Task not found");

            await taskRepository.DeleteAsync(task, cancellationToken);
        }

        public async Task<TaskModel> GetByIdAsync(long userId, long itemId, CancellationToken cancellationToken = default)
        {
            var task = await taskRepository.GetByIdAsync(userId, itemId, cancellationToken);

            if (task == null)
                throw new Exception("Task not found");

            return task;
        }

        public async Task UpdateByIdAsync(long userId, long itemId, string name,
            string description, TaskProgressStauts status,
            CancellationToken cancellationToken = default)
        {
            var task = await taskRepository.GetByIdAsync(userId, itemId, cancellationToken);

            if (task == null)
                throw new Exception("Task not found");

            task.Name = name;
            task.Description = description;
            task.Status = status;
            task.Updated = DateTime.UtcNow;

            await taskRepository.UpdateAsync(task, cancellationToken);
        }

        public async Task PatchByIdAsync(long userId, long itemId, string? name = null, 
            string? description = null, TaskProgressStauts? status = null, 
            CancellationToken cancellationToken = default)
        {
            var task = await taskRepository.GetByIdAsync(userId, itemId, cancellationToken);
            
            if (task == null)
                throw new Exception("Task not found");
            
            if (name != null)
                task.Name = name;

            if (description != null)
                task.Description = description;
            
            if (status != null)
                task.Status = status.Value;

            task.Updated = DateTime.UtcNow;

            await taskRepository.UpdateAsync(task, cancellationToken);
        }
        public async Task<List<TaskModel>> GetAllAsync(long userId, CancellationToken cancellationToken = default)
        {
            return await taskRepository.GetAllAsync(userId, cancellationToken);

        }
    }
}
