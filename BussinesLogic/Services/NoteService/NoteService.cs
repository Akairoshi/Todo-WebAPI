using DataAccess.Data.NoteRepo;
using DataAccess.Models;

namespace BussinesLogic.Services.NoteService
{
    internal class NoteService(INoteRepository NoteRepository) : INoteService
    {
        public async Task CreateAsync(string text, CancellationToken cancellationToken = default)
        {
            var Note = new NoteModel()
            {
                Text = text,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };

            await NoteRepository.CreateAsync(Note, cancellationToken);
        }

        public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var note = await NoteRepository.GetByIdAsync(id, cancellationToken);

            if (note == null)
                throw new Exception("Note not found");

            await NoteRepository.DeleteAsync(note, cancellationToken);
        }

        public async Task<NoteModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var note = await NoteRepository.GetByIdAsync(id, cancellationToken);

            if (note == null)
                throw new Exception("Note not found");

            return note;
        }
        public async Task PatchByIdAsync(int id, string? name = null, string? text = null, 
            CancellationToken cancellationToken = default)
        {
            var note = await NoteRepository.GetByIdAsync(id, cancellationToken);

            if (note == null)
                throw new Exception("Note not found");

            if (name != null)
                note.Name = name;

            if(text != null)
                note.Text = text;

            note.Updated = DateTime.UtcNow;

            await NoteRepository.UpdateAsync(note, cancellationToken);
        }
        public async Task UpdateByIdAsync(int id, string name, string text, 
            CancellationToken cancellationToken = default)
        {
            var note = await NoteRepository.GetByIdAsync(id, cancellationToken);

            if (note == null)
                throw new Exception("Note not found");

            note.Name = name;
            note.Text = text;
            note.Updated = DateTime.UtcNow;

            await NoteRepository.UpdateAsync(note, cancellationToken);
        }

    }
}
