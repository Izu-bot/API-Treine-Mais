using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreineMais.Domain.Entity;

namespace TreineMais.Infrastructure.EntityConfiguration;

public class RoutineEntityConfiguration : IEntityTypeConfiguration<Routine>
{
    public void Configure(EntityTypeBuilder<Routine> builder)
    {
        builder.ToTable("Routines");
        
        builder.HasKey(r => r.Id);
        
        builder.Property(r => r.Id)
            .ValueGeneratedOnAdd();
            
        builder.Property(r => r.UserId)
            .IsRequired();
            
        builder.Property(r => r.Name)
            .HasMaxLength(100)
            .IsRequired();
            
        builder.Property(r => r.Description)
            .HasMaxLength(500)
            .IsRequired(false);

        // Relacionamento com User
        builder.HasOne<User>()
            .WithMany(u => u.Routines)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento com Trainings (1:N)
        builder.HasMany(r => r.Trainings)
            .WithOne() // Se Training não referencia Routine, deixe vazio
            .HasForeignKey("RoutineId") // Shadow property
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(r => r.UserId);
        builder.HasIndex(r => r.Name);
    }
}