using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data.NoteRepo
{
    internal class NoteRepository(AppDbContext context) : INoteRepository
    {
        public async Task CreateAsync(NoteModel note, CancellationToken cancellationToken = default)
        {
            await context.Notes.AddAsync(note, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<NoteModel?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.Notes.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<NoteModel?> UpdateAsync(NoteModel note, CancellationToken cancellationToken = default)
        {
            await context.SaveChangesAsync(cancellationToken);

            return note;
        }
        public async Task DeleteAsync(NoteModel note, CancellationToken cancellationToken = default)
        {
            context.Notes.Remove(note);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
