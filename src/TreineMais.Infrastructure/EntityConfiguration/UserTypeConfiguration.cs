using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreineMais.Domain.Entity;

namespace TreineMais.Infrastructure.EntityConfiguration;

internal class UserTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Active)
            .HasDefaultValue(true);
        builder.Property(u => u.CreatedAt)
            .HasConversion(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
            );

        builder.ComplexProperty(u => u.Login, loginBuilder =>
        {
            loginBuilder.ComplexProperty(l => l.Email, emailBuilder =>
            {
                emailBuilder.Property(e => e.Value)
                    .HasMaxLength(300)
                    .IsRequired();
            });
            loginBuilder.ComplexProperty(l => l.Password, passwordBuilder =>
            {
                passwordBuilder.Property(p => p.Value)
                    .IsRequired();
            });
        });

        builder.HasOne(u => u.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<Profile>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}