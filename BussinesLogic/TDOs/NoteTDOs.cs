namespace BussinesLogic.TDOs
{
    public record CreateNoteDto(long UserId, string Name, string Text);
    public record NoteTDOs(long NoteId, string Name, string? Text);
    public record UpdateNoteDto(string Name, string Text);
    public record PatchNoteDto(string? Name, string? Text);
}
