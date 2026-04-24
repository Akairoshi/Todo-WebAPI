using BussinesLogic.Services.NoteService;
using BussinesLogic.TDOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("Note")]
    public class NoteController(INoteService noteService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync(string text)
        {
            await noteService.CreateAsync(text);
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetNoteAsync([FromRoute] int id)
        {
            var result = await noteService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateByIdAsync([FromRoute]int id, [FromBody]UpdateNoteDto dto)
        {
            await noteService.UpdateByIdAsync(id, dto.Name, dto.Text);
            return NoContent();
        }

        [HttpPatch("{id:int}")]

        public async Task<IActionResult> PatchByIdAsync([FromRoute]int id, [FromBody]PatchNoteDto dto)
        {
            await noteService.PatchByIdAsync(id, dto.Name, dto.Text);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] int id)
        {
            await noteService.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}
