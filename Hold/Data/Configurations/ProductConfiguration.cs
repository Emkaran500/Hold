using Hold.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hold.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> productBuilder)
    {
        productBuilder.HasKey(p => p.Id);

        productBuilder.Property(p => p.ProductName).HasMaxLength(40);

        productBuilder.Property(p => p.LeftInStock).HasColumnName("Left in stock");

        productBuilder.Property(p => p.Texture).HasColumnName("Texture path");
    }
}
