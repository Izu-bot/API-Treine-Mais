using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TreineMais.Domain.Entity;
using TreineMais.Domain.ValueObject;

namespace TreineMais.Infrastructure.EntityConfiguration;

internal class ProfileTypeConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable("Profiles");

        builder.HasKey(p => p.UserId);

        builder.Property(g => g.Gender)
            .HasConversion(new EnumToStringConverter<Gender>())
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.BirthDate).HasColumnType("Date");
        builder.ComplexProperty(h => h.Height, heightBuilder =>
        {
            heightBuilder.Property(h => h.Value)
                .HasColumnType("numeric(4,2)")
                .IsRequired();
        });
        builder.ComplexProperty(w => w.Weight, weightBuilder =>
        {
            weightBuilder.Property(w => w.Value)
                .HasColumnType("numeric(5,2)")
                .IsRequired();
        });
        builder.Property(p => p.Goals)
            .HasColumnType("varchar(300)")
            .IsRequired(false);
    }
}