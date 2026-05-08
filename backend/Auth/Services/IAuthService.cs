namespace Auth.Services
{
    using RegisterDto = Dtos.Dtos.RegisterDto;
    using LoginDto = Dtos.Dtos.LoginDto;
    public interface IAuthService
    {

        Task RegisterAsync(RegisterDto registerDto, CancellationToken cancellation = default);
        Task<string> LoginAsync(LoginDto loginDto, CancellationToken cancellation = default);
    }
}
