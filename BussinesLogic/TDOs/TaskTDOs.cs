using DataAccess.Models;

namespace BussinesLogic.TDOs
{
    public record CreateTaskDto(long UserId, string Name, string? Description);
    public record UpdateTaskDto(string Name, string Description, TaskProgressStauts Status);
    public record PatchTaskDto(string? Name, string? Description, TaskProgressStauts? Status);
}
