using DataAccess.Models;

namespace DataAccess.Data.UserRepo
{
    public interface IUserRepository
    {
        Task CreateAsync(UserModel user, CancellationToken cancellationToken = default);
        Task<UserModel?> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<UserModel?> GetByNameAsync(string userName, CancellationToken cancellationToken = default);
        Task<UserModel?> UpdateAsync(UserModel user, CancellationToken cancellationToken = default);
        Task DeleteAsync(UserModel user, CancellationToken cancellationToken = default);
    }
}
