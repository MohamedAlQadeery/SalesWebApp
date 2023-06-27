using Microsoft.EntityFrameworkCore;
using SalesWebApp.Domain.ProductCategory;

namespace SalesWebApp.Infrastructure.Persistence;

public class AppDbContext : DbContext
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

}