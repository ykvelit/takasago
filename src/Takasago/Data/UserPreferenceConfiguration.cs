using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Takasago.Domain;

namespace Takasago.Data;

public class UserPreferenceConfiguration : IEntityTypeConfiguration<UserPreference>
{
    public void Configure(EntityTypeBuilder<UserPreference> builder)
    {
        builder.ToTable("UserPreferences");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Key);
        builder.HasIndex(x => x.UserId);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.Key)
            .HasColumnName("Key")
            .IsRequired();

        builder.Property(x => x.Preference)
            .HasColumnName("Preference")
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasColumnName("UserId")
            .IsRequired();
    }
}