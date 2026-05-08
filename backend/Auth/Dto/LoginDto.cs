namespace Auth.Dtos
{
    public class Dtos
    {
        public record RegisterDto(string Name, string Password);
        public record LoginDto(string Name, string Password);
    }
}
