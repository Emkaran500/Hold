using Hold.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hold.Data.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> countryBuilder)
    {
        countryBuilder.HasKey(c => c.Id);

        countryBuilder.Property(c => c.CountryName).IsRequired().HasMaxLength(50);
    }
}
