namespace DataAccess.Models
{
    public class NoteModel
    {
        public long UserId { get; set; }
        public long ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
