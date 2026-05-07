using Auth.Configuration;
using DataAccess.Data.UserRepo;
using DataAccess.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.Services
{
    using LoginDto = Dtos.Dtos.LoginDto;
    using RegisterDto = Dtos.Dtos.RegisterDto;
    public class AuthService(IUserRepository userRepository, IOptions<JwtConfiguration> jwtConfig) : IAuthService
    {
        public async Task<string> LoginAsync(LoginDto loginDto, CancellationToken cancellation = default)
        {
            var user = await userRepository.GetByNameAsync(loginDto.Name, cancellation);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid username or password");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Value.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name)
            };

            var token = new JwtSecurityToken(
                issuer: jwtConfig.Value.Issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(jwtConfig.Value.ExpiresInHours),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task RegisterAsync(RegisterDto registerDto, CancellationToken cancellation = default)
        {
            var existing = await userRepository.GetByNameAsync(registerDto.Name, cancellation);
            if (existing != null)
                throw new InvalidOperationException("User with this name already exists");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            await userRepository.CreateAsync(new UserModel
            {
                Name = registerDto.Name,
                PasswordHash = passwordHash
            }, cancellation);
        }
    }
}
