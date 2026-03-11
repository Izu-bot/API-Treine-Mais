using System.ComponentModel;
using TreineMais.Domain.Entity;

namespace TreineMais.Domain.Abstractions;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetByToken(string token);
    Task<ICollection<RefreshToken>> GetByUserId(Guid userId);
    Task Add(RefreshToken token);
    Task Revoke(RefreshToken token);
}