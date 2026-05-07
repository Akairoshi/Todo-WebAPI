using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.Data.UserRepo
{
    internal class UserRepository(AppDbContext context, ILogger<UserRepository> logger) : IUserRepository
    {
        public async Task CreateAsync(UserModel user, CancellationToken cancellationToken = default)
        {
            await context.Users.AddAsync(user, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            logger.LogInformation("User created with ID: {UserId}", user.Id);
        }

        public async Task DeleteAsync(UserModel user, CancellationToken cancellationToken = default)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync(cancellationToken);
            logger.LogInformation("User deleted with ID: {UserId}", user.Id);
        }

        public async Task<UserModel?> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
            logger.LogInformation("User retrieved with ID: {UserId}", userId);
            return user;
        }

        public async Task<UserModel?> GetByNameAsync(string userName, CancellationToken cancellationToken = default)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Name == userName, cancellationToken);
            logger.LogInformation("User retrieved with ID: {UserName}", userName);
            return user;
        }

        public async Task<UserModel?> UpdateAsync(UserModel user, CancellationToken cancellationToken = default)
        {
            await context.SaveChangesAsync(cancellationToken);
            logger.LogInformation("User updated with ID: {UserId}", user.Id);
            return user;
        }
    }
}
