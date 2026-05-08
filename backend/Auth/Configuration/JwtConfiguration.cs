namespace Auth.Configuration
{
    public class JwtConfiguration
    {
        public string SecretKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public int ExpiresInHours { get; set; }
    }
}
