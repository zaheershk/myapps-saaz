using saaz.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace saaz.Catalog.Data.Configurations
{
    public class CatalogSubCategoryConfiguration : IEntityTypeConfiguration<CatalogSubCategory>
    {
        public void Configure(EntityTypeBuilder<CatalogSubCategory> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.SubCategoryName)
                .IsRequired()
                .HasMaxLength(100);

            //fk settings
            builder.HasOne(ct => ct.Category)
                .WithMany(sc => sc.SubCategories)
                .HasForeignKey(fk => fk.CategoryId);
            //.HasConstraintName("FK_CST_CTGRYID");
        }
    }
}
