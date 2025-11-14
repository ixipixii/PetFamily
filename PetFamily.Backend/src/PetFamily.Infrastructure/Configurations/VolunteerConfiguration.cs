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
        builder.ToTable("volunteers");
        
        builder.HasKey(v => v.Id);
        
        builder.Property(v => v.Id)
            .HasConversion(id => id.Value, value => VolunteerId.Create(value))
            .HasColumnName("id");
        
        builder.Property(v => v.FullName)
            .IsRequired(true)
            .HasMaxLength(Constants.MAX_NAME_LENGTH)
            .HasColumnName("full_name");
        
        builder.Property(v => v.Description)
            .HasMaxLength(Constants.MAX_DESCRIPTION_LENGTH)
            .HasColumnName("description");

        builder.ComplexProperty(v => v.Email,
                eb =>
                {
                    eb.Property(e => e.Address)
                        .IsRequired()
                        .HasMaxLength(Constants.MAX_NAME_LENGTH)
                        .HasColumnName("email");
                });
        
        builder.Property(v => v.Experience)
            .HasDefaultValue(0)
            .HasColumnName("experience");

        builder.HasMany(v => v.Pets)
            .WithOne()
            .HasForeignKey("volunteer_id")
            .OnDelete(DeleteBehavior.NoAction);

        builder.ComplexProperty(v => v.Phone,
            p =>
            {
                p.Property(p => p.Number)
                    .IsRequired()
                    .HasColumnName("phone");
            });

        builder.Property(v => v.SocialNetworks)
            .HasColumnType("jsonb")
            .JsonValueObjectCollectionConversion()
            .HasColumnName("social_networks");
        
        builder.Property(v => v.Requisites)
            .HasColumnType("jsonb")
            .JsonValueObjectCollectionConversion()
            .HasColumnName("requisites");
    }
}