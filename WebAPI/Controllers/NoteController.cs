using BussinesLogic.Dtos;
using BussinesLogic.Services.NoteService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Note")]
    public class NoteController(INoteService noteService) : ControllerBase
    {
        [HttpPost("{userId:Guid}")]
        public async Task<IActionResult> CreateAsync([FromRoute] Guid userId, [FromBody] CreateNoteDto dto, CancellationToken ct)
        {
            await noteService.CreateAsync(userId, dto, ct);
            return NoContent();
        }
        [HttpGet("{userId:Guid}")]
        public async Task<IActionResult> GetAllAsync([FromRoute] Guid userId, CancellationToken ct)
        {
            var result = await noteService.GetAllAsync(userId, ct);
            return Ok(result);
        }

        [HttpGet("{userId:Guid}/{id:Guid}")]
        public async Task<IActionResult> GetNoteAsync([FromRoute] Guid userId, [FromRoute] Guid id, CancellationToken ct)
        {
            var result = await noteService.GetByIdAsync(userId, id, ct);
            return Ok(result);
        }

        [HttpPut("{userId:Guid}/{id:Guid}")]
        public async Task<IActionResult> UpdateByIdAsync([FromRoute] Guid userId, [FromRoute] Guid id, [FromBody] UpdateNoteDto dto, CancellationToken ct)
        {
            await noteService.UpdateByIdAsync(userId, id, dto, ct);
            return NoContent();
        }

        [HttpPatch("{userId:Guid}/{id:Guid}")]
        public async Task<IActionResult> PatchByIdAsync([FromRoute] Guid userId, [FromRoute] Guid id, [FromBody] PatchNoteDto dto, CancellationToken ct)
        {
            await noteService.PatchByIdAsync(userId, id, dto, ct);
            return NoContent();
        }

        [HttpDelete("{userId:Guid}/{id:Guid}")]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] Guid userId, [FromRoute] Guid id, CancellationToken ct)
        {
            await noteService.DeleteByIdAsync(userId, id, ct);
            return NoContent();
        }
    }
}
