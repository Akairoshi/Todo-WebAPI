namespace DataAccess.Models
{
    public class NoteModel
    {
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
