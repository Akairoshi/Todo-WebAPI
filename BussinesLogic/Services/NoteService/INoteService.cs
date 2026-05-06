using DataAccess.Models;

namespace BussinesLogic.Services.NoteService
{
    public interface INoteService
    {
        Task CreateAsync(long userId, string name, string text, CancellationToken cancellationToken = default);
        Task<NoteModel> GetByIdAsync(long userId, long itemId, CancellationToken cancellation = default);
        Task PatchByIdAsync(long userId, long itemId, string? name = null, string? text = null, 
            CancellationToken cancellationToken = default);
        Task UpdateByIdAsync(long userId, long itemId, string name, string text, 
            CancellationToken cancellationToken = default);
        Task DeleteByIdAsync(long userId, long itemId, CancellationToken cancellationToken = default);
        Task<List<NoteModel>> GetAllAsync(long userId, CancellationToken cancellationToken = default);
    }
}
