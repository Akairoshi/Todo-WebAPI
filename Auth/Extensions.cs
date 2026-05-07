using Auth.Configuration;
using Auth.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth
{
    public static class Extensions
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtConfiguration>(configuration.GetSection("JwtConfiguration"));
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
