using BussinesLogic.Services.NoteService;
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
        public async Task<IActionResult> CreateAsync(string name, [FromBody]string description)
        {
            await taskService.CreateAsync(name, description);
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetNoteAsync([FromRoute] int id)
        {
            var result = await taskService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateByIdAsync([FromRoute] int id, [FromBody] UpdateTaskDto dto)
        {
            await taskService.UpdateByIdAsync(id, dto.Name, dto.Description, dto.Status);
            return NoContent();
        }

        [HttpPatch("{id:int}")]

        public async Task<IActionResult> PatchByIdAsync([FromRoute] int id, [FromBody] PatchTaskDto dto)
        {
            await taskService.PatchByIdAsync(id, dto.Name, dto.Description, dto.Status);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] int id)
        {
            await taskService.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}
