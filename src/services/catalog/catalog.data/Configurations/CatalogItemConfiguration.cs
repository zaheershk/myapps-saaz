using saaz.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace saaz.Catalog.Data.Configurations
{
    public class CatalogItemConfiguration : IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.HasKey(e => e.Id);

            //builder.Property(e => e.Id).HasColumnName("Id");
            //builder.Property(e => e.TypeId).HasColumnName("TypeId");
            //builder.Property(e => e.BrandId).HasColumnName("BrandId");
            //builder.Property(e => e.CategoryId).HasColumnName("CategoryId");
            //builder.Property(e => e.SubCategoryId).HasColumnName("SubCategoryId");

            builder.Property(e => e.ItemName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.ItemDesc).HasMaxLength(250);
            builder.Property(e => e.Price).HasMaxLength(20);

            builder.Property(e => e.PictureFileName).HasMaxLength(20);
            builder.Property(e => e.PictureUri).HasMaxLength(20);
            builder.Property(e => e.CreateBy).HasMaxLength(10);
            builder.Property(e => e.UpdateBy).HasMaxLength(10);

            //fk settings
            builder.HasOne(ct => ct.Type)
                .WithMany(ci => ci.CatalogItems)
                .HasForeignKey(fk => fk.TypeId)
                .HasConstraintName("FK_CI_TYPEID");

            builder.HasOne(cb => cb.Brand)
                .WithMany(ci => ci.CatalogItems)
                .HasForeignKey(fk => fk.BrandId)
                .HasConstraintName("FK_CI_BRANDID");

            builder.HasOne(cc => cc.Category)
                .WithMany(ci => ci.CatalogItems)
                .HasForeignKey(fk => fk.CategoryId)
                .HasConstraintName("FK_CI_CATEGORYID");

            builder.HasOne(csc => csc.SubCategory)
                .WithMany(ci => ci.CatalogItems)
                .HasForeignKey(fk => fk.SubCategoryId)
                .HasConstraintName("FK_CI_SUBCATEGORYID");
        }
    }
}
