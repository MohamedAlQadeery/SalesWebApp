using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesWebApp.Domain.ProductCategoryEntity;
using SalesWebApp.Domain.ProductEntity;

namespace SalesWebApp.Infrastructure.Persistence.Configurations;
public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{

    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {

        ConfigureProductCategoryTable(builder);



    }

    private void ConfigureProductCategoryTable(EntityTypeBuilder<ProductCategory> builder)
    {

        builder.HasMany(p => p.Products)
               .WithOne(c => c.Category)
               .HasForeignKey(p => p.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);



    }
}