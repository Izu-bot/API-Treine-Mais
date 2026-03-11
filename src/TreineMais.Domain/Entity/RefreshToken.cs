using System.Security.Cryptography;

namespace TreineMais.Domain.Entity;

public class RefreshToken
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid UserId { get; private set; }
    public string Token { get; private set; } = string.Empty;
    public DateTime ExpiresAt { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? RevokedAt { get; private set; }
    
    private RefreshToken() { }

    public RefreshToken(Guid userId)
    {
        UserId = userId;
        Token = GenerateRefreshToken();
        ExpiresAt = DateTime.UtcNow.AddMonths(3);
        CreatedAt = DateTime.UtcNow;
    }

    private static string GenerateRefreshToken()
    {
        var token = RandomNumberGenerator.GetBytes(32);
        return Convert.ToBase64String(token);
    }

    public void Revoke()
    {
        RevokedAt = DateTime.UtcNow;
    }
    
    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
    public bool IsRevoked => RevokedAt is not null;
}