using BussinesLogic.Services.NoteService;
using BussinesLogic.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("Note")]
    public class NoteController(INoteService noteService) : ControllerBase
    {
        [HttpPost("{userId:long}")]
        public async Task<IActionResult> CreateAsync([FromRoute] long userId, [FromBody] CreateNoteDto dto, CancellationToken ct)
        {
            await noteService.CreateAsync(userId, dto, ct);
            return NoContent();
        }
        [HttpGet("{userId:long}")]
        public async Task<IActionResult> GetAllAsync([FromRoute] long userId, CancellationToken ct)
        {
            var result = await noteService.GetAllAsync(userId, ct);
            return Ok(result);
        }

        [HttpGet("{userId:long}/{id:long}")]
        public async Task<IActionResult> GetNoteAsync([FromRoute] long userId, [FromRoute] long id, CancellationToken ct)
        {
            var result = await noteService.GetByIdAsync(userId, id, ct);
            return Ok(result);
        }

        [HttpPut("{userId:long}/{id:long}")]
        public async Task<IActionResult> UpdateByIdAsync([FromRoute] long userId, [FromRoute] long id, [FromBody] UpdateNoteDto dto, CancellationToken ct)
        {
            await noteService.UpdateByIdAsync(userId, id, dto, ct);
            return NoContent();
        }

        [HttpPatch("{userId:long}/{id:long}")]
        public async Task<IActionResult> PatchByIdAsync([FromRoute] long userId, [FromRoute] long id, [FromBody] PatchNoteDto dto, CancellationToken ct)
        {
            await noteService.PatchByIdAsync(userId, id, dto, ct);
            return NoContent();
        }

        [HttpDelete("{userId:long}/{id:long}")]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] long userId, [FromRoute] long id, CancellationToken ct)
        {
            await noteService.DeleteByIdAsync(userId, id, ct);
            return NoContent();
        }
    }
}
