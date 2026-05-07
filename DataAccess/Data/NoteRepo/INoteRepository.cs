using DataAccess.Models;

namespace DataAccess.Data.NoteRepo
{
    public interface INoteRepository
    {
        Task CreateAsync(NoteModel note, CancellationToken cancellationToken = default);
        Task<NoteModel?> GetByIdAsync(Guid userId, Guid itemId, CancellationToken cancellationToken = default);
        Task<NoteModel?> UpdateAsync(NoteModel note, CancellationToken cancellationToken = default);
        Task DeleteAsync(NoteModel note, CancellationToken cancellationToken = default);
        Task<List<NoteModel>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}
