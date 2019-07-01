using saaz.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace saaz.Catalog.Data.Configurations
{
    public class CatalogBrandConfiguration : IEntityTypeConfiguration<CatalogBrand>
    {
        public void Configure(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.BrandName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
