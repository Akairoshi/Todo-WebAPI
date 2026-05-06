using BussinesLogic.Services.TaskService;
using BussinesLogic.TDOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("Task")]
    public class TaskController(ITaskService taskService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateTaskDto dto, CancellationToken ct)
        {
            await taskService.CreateAsync(dto.UserId, dto.Name, dto.Description, ct);
            return NoContent();
        }

        [HttpGet("{userId:long}/{id:long}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long userId, [FromRoute] long id, CancellationToken ct)
        {
            var result = await taskService.GetByIdAsync(userId, id, ct);
            return Ok(result);
        }
        [HttpGet("{userId:long}")]
        public async Task<IActionResult> GetAllAsync([FromRoute] long userId, CancellationToken ct)
        {
            var result = await taskService.GetAllAsync(userId, ct);
            return Ok(result);
        }

        [HttpPut("{userId:long}/{id:long}")]
        public async Task<IActionResult> UpdateByIdAsync([FromRoute] long userId, [FromRoute] long id, [FromBody] UpdateTaskDto dto, CancellationToken ct)
        {
            await taskService.UpdateByIdAsync(userId, id, dto.Name, dto.Description, dto.Status, ct);
            return NoContent();
        }

        [HttpPatch("{userId:long}/{id:long}")]
        public async Task<IActionResult> PatchByIdAsync([FromRoute] long userId, [FromRoute] long id, [FromBody] PatchTaskDto dto, CancellationToken ct)
        {
            await taskService.PatchByIdAsync(userId, id, dto.Name, dto.Description, dto.Status, ct);
            return NoContent();
        }

        [HttpDelete("{userId:long}/{id:long}")]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] long userId, [FromRoute] long id, CancellationToken ct)
        {
            await taskService.DeleteByIdAsync(userId, id, ct);
            return NoContent();
        }
    }
}
