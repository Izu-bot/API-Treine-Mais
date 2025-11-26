using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreineMais.Domain.Entity;

namespace TreineMais.Infrastructure.EntityConfiguration;

internal class ExercisesTypeConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.ToTable("Exercises");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.Description)
            .HasMaxLength(100)
            .IsRequired(false);
        builder.Property(e => e.Category).HasMaxLength(50).IsRequired();

        builder.HasOne<User>()
            .WithMany(u => u.Exercises)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}