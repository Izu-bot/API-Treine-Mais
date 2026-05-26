using Microsoft.EntityFrameworkCore;
using TreineMais.Domain.Abstractions;
using TreineMais.Domain.Entity;
using TreineMais.Infrastructure.Context;

namespace TreineMais.Infrastructure.Persistence;

internal class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task TrackerSynchronizeAsync(User user)
    {
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Login.Email.Value == email);
    }

    public async Task<User?> GetByEmailConfirmationTokenAsync(string token)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.EmailConfirmedToken == token);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users
            .AsNoTracking()
            .Include(u => u.Profile)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}