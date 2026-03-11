using Microsoft.EntityFrameworkCore;
using TreineMais.Domain.Abstractions;
using TreineMais.Domain.Entity;
using TreineMais.Infrastructure.Context;

namespace TreineMais.Infrastructure.Persistence;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly ApplicationDbContext _context;
    
    public RefreshTokenRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<RefreshToken?> GetByToken(string token)
        => await _context.RefreshTokens.SingleOrDefaultAsync(t => t.Token == token);

    public async Task<ICollection<RefreshToken>> GetByUserId(Guid userId)
        => await _context
            .RefreshTokens
            .Where(t => t.UserId == userId)
            .ToListAsync();

    public Task Add(RefreshToken token)
    {
        _context.RefreshTokens.Add(token);
        return _context.SaveChangesAsync();
    }

    public Task Revoke(RefreshToken token)
    {
        token.Revoke();
        
        _context.RefreshTokens.Update(token);
        return _context.SaveChangesAsync();
    }
}