using Hold.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hold.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> userBuilder)
    {
        userBuilder.HasKey(u => u.Id);

        userBuilder.Property(u => u.ProfileName).IsRequired().HasMaxLength(30).HasColumnName("Name");

        userBuilder.Property(u => u.ProfilePassword).IsRequired().HasMaxLength(20).HasColumnName("Password");

        userBuilder.Property(u => u.Balance).IsRequired();

        userBuilder.Property(u => u.Email).HasMaxLength(30).HasDefaultValue("Unknown");

        userBuilder.Property(u => u.ProfilePhoneNumber).HasMaxLength(15).HasDefaultValue("Unknown").HasColumnName("Phone number") ;
    }
}
