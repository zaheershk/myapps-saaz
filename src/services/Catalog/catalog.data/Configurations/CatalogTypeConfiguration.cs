using saaz.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace saaz.Catalog.Data.Configurations
{
    public class CatalogTypeConfiguration : IEntityTypeConfiguration<CatalogType>
    {
        public void Configure(EntityTypeBuilder<CatalogType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.TypeName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
