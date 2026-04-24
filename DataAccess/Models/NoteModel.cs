namespace DataAccess.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
