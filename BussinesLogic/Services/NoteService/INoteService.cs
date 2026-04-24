using DataAccess.Models;

namespace BussinesLogic.Services.NoteService
{
    public interface INoteService
    {
        Task CreateAsync(string text, CancellationToken cancellationToken = default);
        Task<NoteModel> GetByIdAsync(int id, CancellationToken cancellation = default);
        Task PatchByIdAsync(int id, string? name = null, string? text = null, 
            CancellationToken cancellationToken = default);
        Task UpdateByIdAsync(int id, string name, string text, 
            CancellationToken cancellationToken = default);
        Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
