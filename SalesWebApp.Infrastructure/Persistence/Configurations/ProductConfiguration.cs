using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesWebApp.Domain.ProductCategoryEntity;
using SalesWebApp.Domain.ProductEntity;

namespace SalesWebApp.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        ConfigureProductTable(builder);
        ConfigureProductSpecifcationsTable(builder);
        ConfigureProductAttachmentsTable(builder);
    }

    private void ConfigureProductTable(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey("Id");

        builder.OwnsOne(p => p.ProjectOwnerPrice);
        builder.OwnsOne(p => p.SalesmanPrice);
        builder.OwnsOne(p => p.CustomerPrice);

        builder.HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);






    }


    private void ConfigureProductSpecifcationsTable(EntityTypeBuilder<Product> builder)
    {
        builder.OwnsMany(p => p.ProductSpecifications, ps =>
        {
            ps.ToTable("ProductSpecifications");

            ps.WithOwner().HasForeignKey("ProductId");
            ps.HasKey("Id", "ProductId");



        });

        builder.Metadata.FindNavigation(nameof(Product.ProductSpecifications))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);

    }


    private void ConfigureProductAttachmentsTable(EntityTypeBuilder<Product> builder)
    {
        builder.OwnsMany(p => p.ProductAttachments, ps =>
        {
            ps.ToTable("ProductAttachments");

            ps.WithOwner().HasForeignKey("ProductId");
            ps.HasKey("Id", "ProductId");
        });

        builder.Metadata.FindNavigation(nameof(Product.ProductAttachments))!
              .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
