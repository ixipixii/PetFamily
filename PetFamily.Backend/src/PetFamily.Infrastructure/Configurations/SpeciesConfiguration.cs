using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;

namespace PetFamily.Infrastructure.Configurations;

public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
{
    public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.ToTable("Species");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .HasConversion(id => id.Value,
                           id => SpeciesId.Create(id));
        builder.Property(s => s.Title)
            .IsRequired(true)
            .HasMaxLength(Constants.MAX_TITLE_LENGTH);
        builder.HasMany(s => s.Breeds)
            .WithOne()
            .HasForeignKey("species_id")
            .OnDelete(DeleteBehavior.NoAction);
    }
}