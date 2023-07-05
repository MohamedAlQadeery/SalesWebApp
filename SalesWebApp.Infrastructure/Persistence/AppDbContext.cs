using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalesWebApp.Domain.AppUserEntity;
using SalesWebApp.Domain.ProductCategoryEntity;
using SalesWebApp.Domain.ProductEntity;

namespace SalesWebApp.Infrastructure.Persistence;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;





}