using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
using PetFamily.Domain.Shared.Extensions;
using PetFamily.Domain.Volunteers;
using PetFamily.Domain.Volunteers.VO;
using Constants = PetFamily.Domain.Shared.Constants;

namespace PetFamily.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("Pet");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasConversion(id => id.Value, 
                           value => PetId.Create(value));
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(Constants.MAX_NAME_LENGTH);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(Constants.MAX_DESCRIPTION_LENGTH);
        
        builder.Property(p => p.Color);
        builder.Property(p => p.Health);

        builder.Property(p => p.Address)
            .HasColumnType("jsonb")
            .JsonValueObjectConversion();
        
        builder.Property(p => p.Species)
            .HasColumnType("jsonb")
            .JsonValueObjectConversion();
        
        builder.Property(p => p.Breed)
            .HasColumnType("jsonb")
            .JsonValueObjectConversion();

        builder.Property(p => p.Weight);
        builder.Property(p => p.Growth);

        builder.Property(p => p.Phone)
            .HasColumnType("jsonb")
            .JsonValueObjectConversion();

        builder.Property(p => p.Castrated);
        builder.Property(p => p.BirthDate);
        builder.Property(p => p.Vaccinated);
        builder.Property(p => p.HelpStatus);

        builder.Property(p => p.Requisites)
            .HasColumnType("jsonb")
            .JsonValueObjectCollectionConversion();
        
        builder.Property(p => p.Photos)
            .HasColumnType("jsonb")
            .JsonValueObjectCollectionConversion();
        
        builder.Property(p => p.CreationDate);
    }
}