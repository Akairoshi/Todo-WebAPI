using BussinesLogic.TDOs;
using DataAccess.Models;

namespace BussinesLogic.Services.NoteService
{
    public interface INoteService
    {
        Task CreateAsync(long userId, CreateNoteDto dto, CancellationToken cancellationToken = default);
        Task<NoteModel> GetByIdAsync(long userId, long itemId, CancellationToken cancellation = default);
        Task PatchByIdAsync(long userId, long itemId, PatchNoteDto dto, CancellationToken cancellationToken = default);
        Task UpdateByIdAsync(long userId, long itemId, UpdateNoteDto dto, 
            CancellationToken cancellationToken = default);
        Task DeleteByIdAsync(long userId, long itemId, CancellationToken cancellationToken = default);
        Task<List<NoteModel>> GetAllAsync(long userId, CancellationToken cancellationToken = default);
    }
}
