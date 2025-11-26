using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreineMais.Domain.Entity;

namespace TreineMais.Infrastructure.EntityConfiguration;

public class TrainingEntityConfiguration : IEntityTypeConfiguration<Training>
{
    public void Configure(EntityTypeBuilder<Training> builder)
    {
        builder.ToTable("Trainings");
        
        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd();
            
        builder.Property(t => t.UserId)
            .IsRequired();
            
        builder.Property(t => t.Name)
            .HasMaxLength(100)
            .IsRequired();
            
        builder.Property(t => t.Description)
            .HasMaxLength(500)
            .IsRequired(false);
            
        builder.Property(t => t.Date)
            .IsRequired();

        // Relacionamento com User
        builder.HasOne<User>()
            .WithMany(u => u.Trainings)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento com TrainingExercise (Owned Collection)
        builder.OwnsMany(t => t.Exercises, teBuilder =>
        {
            teBuilder.ToTable("TrainingExercises");
    
            teBuilder.WithOwner()
                .HasForeignKey("TrainingId");
    
            teBuilder.HasKey("Id", "TrainingId");
    
            teBuilder.Property(te => te.ExerciseId)
                .IsRequired();
        
            teBuilder.Property(te => te.Sets)
                .IsRequired();
        
            teBuilder.Property(te => te.Reps)
                .IsRequired();

            teBuilder.OwnsOne(te => te.Weight, weightBuilder =>
            {
                weightBuilder.Property(w => w.Value)
                    .HasColumnName("WeightValue")
                    .IsRequired();
            });

            teBuilder.HasOne<Exercise>()
                .WithMany()
                .HasForeignKey(te => te.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            teBuilder.Property<int>("Id")
                .ValueGeneratedOnAdd();
        });

        builder.HasIndex(t => t.UserId);
        builder.HasIndex(t => t.Date);
    }
}
