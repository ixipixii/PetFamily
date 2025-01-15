using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Shared.Extensions;
using PetFamily.Domain.Volunteers;
using PetFamily.Domain.Volunteers.VO;

namespace PetFamily.Infrastructure.Configurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("Volunteers");
        
        builder.HasKey(v => v.Id);
        
        builder.Property(v => v.Id)
                                     .HasConversion(id => id.Value,
                                                    value => VolunteerId.Create(value));
        builder.Property(v => v.FullName)
            .IsRequired(true)
            .HasMaxLength(Constants.MAX_NAME_LENGTH);
        
        builder.Property(v => v.Description)
            .IsRequired()
            .HasMaxLength(Constants.MAX_DESCRIPTION_LENGTH);

        builder.Property(v => v.Email)
            .HasMaxLength(Constants.MAX_NAME_LENGTH);

        builder.Property(v => v.Experience)
            .HasDefaultValue(0);

        builder.HasMany(v => v.Pets)
            .WithOne()
            .HasForeignKey("volunteer_id")
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(v => v.Phone)
            .HasColumnType("jsonb")
            .JsonValueObjectConversion();

        builder.Property(v => v.SocialNetworks)
            .HasColumnType("jsonb")
            .JsonValueObjectCollectionConversion();
        
        builder.Property(v => v.Requisites)
            .HasColumnType("jsonb")
            .JsonValueObjectCollectionConversion();
    }
}