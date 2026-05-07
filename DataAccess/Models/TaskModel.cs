
namespace DataAccess.Models
{
    public class TaskModel
    {
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TaskProgressStatus Status { get; set; } = TaskProgressStatus.NotStarted;
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
    public enum TaskProgressStatus
    {
        NotStarted,
        InProgress,
        Done
    }
}
