using TreineMais.Domain.Entity;
using TreineMais.Domain.ValueObject;

namespace TreineMais.Domain.Abstractions;

public interface IUserRepository
{
    Task CreateUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(User user);
    Task<User?> GetUserByIdAsync(Guid id);
    Task<User?> GetUserByEmailAsync(Email email);
}