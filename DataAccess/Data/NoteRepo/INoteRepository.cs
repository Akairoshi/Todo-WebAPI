using DataAccess.Models;

namespace DataAccess.Data.NoteRepo
{
    public interface INoteRepository
    {
        Task CreateAsync(NoteModel note, CancellationToken cancellationToken = default);
        Task<NoteModel?> GetByIdAsync(long userId, long itemId, CancellationToken cancellationToken = default);
        Task<NoteModel?> UpdateAsync(NoteModel note, CancellationToken cancellationToken = default);
        Task DeleteAsync(NoteModel note, CancellationToken cancellationToken = default);
        Task<List<NoteModel>> GetAllAsync(long userId, CancellationToken cancellationToken = default);
    }
}
