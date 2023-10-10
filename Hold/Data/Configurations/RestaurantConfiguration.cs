using Hold.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hold.Data.Configurations;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> restaurantBuilder)
    {
        restaurantBuilder.HasKey(r => r.Id);

        restaurantBuilder.Property(r => r.Name).HasMaxLength(50).HasColumnName("Name of the restaurant");

        restaurantBuilder.Property(r => r.Texture).HasColumnName("Texture path");
    }
}
