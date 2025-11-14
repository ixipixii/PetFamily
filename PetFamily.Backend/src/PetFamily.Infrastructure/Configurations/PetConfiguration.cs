using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
using PetFamily.Domain.Shared.Extensions;
using PetFamily.Domain.Species;
using PetFamily.Domain.Volunteers;
using PetFamily.Domain.Volunteers.VO;
using Constants = PetFamily.Domain.Shared.Constants;

namespace PetFamily.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pet");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasConversion(id => id.Value, 
                           value => PetId.Create(value))
            .HasColumnName("id");
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(Constants.MAX_NAME_LENGTH)
            .HasColumnName("name");

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(Constants.MAX_DESCRIPTION_LENGTH)
            .HasColumnName("description");
        
        builder.Property(p => p.Color)
            .HasColumnName("color");
        
        builder.Property(p => p.Health)
            .HasColumnName("health");

        builder.Property(p => p.Address)
            .HasColumnType("jsonb")
            .JsonValueObjectConversion()
            .HasColumnName("address");
        
        builder.OwnsOne(
            p => p.SpeciesBreed,
            bsb =>
            {
                bsb.Property(p => p.BreedId)
                    .IsRequired()
                    .HasColumnName("breed_id")
                    .JsonValueObjectConversion();

                bsb.Property(p => p.SpeciesId)
                    .IsRequired()
                    .HasColumnName("species_id")
                    .JsonValueObjectConversion();
            });

        builder.Navigation(p => p.SpeciesBreed).IsRequired(false);

        builder.Property(p => p.Weight)
            .HasColumnName("weight");
        
        builder.Property(p => p.Growth)
            .HasColumnName("growth");

        builder.ComplexProperty(p => p.Phone,
            p =>
            {
                p.Property(p => p.Number)
                    .IsRequired()
                    .HasColumnName("phone");
            });

        builder.Property(p => p.Castrated)
            .HasColumnName("castrated");
        
        builder.Property(p => p.BirthDate)
            .HasColumnName("birth_date");
        
        builder.Property(p => p.Vaccinated)
            .HasColumnName("vaccinated");
        
        builder.Property(p => p.HelpStatus)
            .HasColumnName("help_status");

        builder.Property(p => p.Requisites)
            .HasColumnType("jsonb")
            .JsonValueObjectCollectionConversion()
            .HasColumnName("requisites");
        
        builder.Property(p => p.Photos)
            .HasColumnType("jsonb")
            .JsonValueObjectCollectionConversion()
            .HasColumnName("photos");
        
        builder.Property(p => p.CreationDate)
            .HasColumnName("creation_date");
    }
}