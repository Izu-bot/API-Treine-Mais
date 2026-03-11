using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreineMais.Domain.Entity;

namespace TreineMais.Infrastructure.EntityConfiguration;

public class RefreshTokenTypeConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable(nameof(RefreshToken));

        builder.HasKey(r => r.Id);
        builder.Property(r => r.Token)
            .IsRequired();
        builder.Property(r => r.CreatedAt)
            .HasColumnType("timestamp with time zone")
            .IsRequired();
        builder.Property(r => r.ExpiresAt)
            .HasColumnType("timestamp with time zone")
            .IsRequired();
        builder.Property(r => r.RevokedAt)
            .HasColumnType("timestamp with time zone")
            .IsRequired(false);
        
        builder.Property(r => r.UserId)
            .IsRequired();
        
        builder.HasOne<User>()
            .WithMany(u => u.RefreshTokens)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}