using TreineMais.Domain.Entity;
using TreineMais.Domain.ValueObject;

namespace TreineMais.Domain.Abstractions;

public interface IUserRepository
{
    Task CreateAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAsync(Email email);
}