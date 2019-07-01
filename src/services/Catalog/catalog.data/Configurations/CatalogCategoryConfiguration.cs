using saaz.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace saaz.Catalog.Data.Configurations
{
    public class CatalogCategoryConfiguration : IEntityTypeConfiguration<CatalogCategory>
    {
        public void Configure(EntityTypeBuilder<CatalogCategory> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
