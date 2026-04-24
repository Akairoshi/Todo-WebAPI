
namespace DataAccess.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TaskProgressStauts Status { get; set; } = TaskProgressStauts.NotStarted;
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
