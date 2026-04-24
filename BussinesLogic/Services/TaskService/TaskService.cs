using DataAccess.Data.TaskRepo;
using DataAccess.Models;

namespace BussinesLogic.Services.TaskService
{
    internal class TaskService(ITaskRepository taskRepository) : ITaskService
    {
        public async Task CreateAsync(string name, string? description = null, 
            CancellationToken cancellationToken = default)
        {
            var task = new TaskModel()
            {
                Name = name,
                Description = description,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };

            await taskRepository.CreateAsync(task, cancellationToken);
        }

        public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var task = await taskRepository.GetByIdAsync(id, cancellationToken);

            if (task == null)
                throw new Exception("Task not found");

            await taskRepository.DeleteAsync(task, cancellationToken);
        }

        public async Task<TaskModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var task = await taskRepository.GetByIdAsync(id, cancellationToken);

            if (task == null)
                throw new Exception("Task not found");

            return task;
        }

        public async Task UpdateByIdAsync(int id, string name,
            string description, TaskProgressStauts status,
            CancellationToken cancellationToken = default)
        {
            var task = await taskRepository.GetByIdAsync(id, cancellationToken);

            if (task == null)
                throw new Exception("Task not found");

            task.Name = name;
            task.Description = description;
            task.Status = status;

            task.Updated = DateTime.UtcNow;

            await taskRepository.UpdateAsync(task, cancellationToken);
        }

        public async Task PatchByIdAsync(int id, string? name = null, 
            string? description = null, TaskProgressStauts? status = null, 
            CancellationToken cancellationToken = default)
        {
            var task = await taskRepository.GetByIdAsync(id, cancellationToken);
            
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

    }
}
