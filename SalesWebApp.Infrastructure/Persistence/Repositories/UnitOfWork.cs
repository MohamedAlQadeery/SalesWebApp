using SalesWebApp.Application.Abstractions.Repositories;
using SalesWebApp.Domain.ProductCategoryEntity;
using SalesWebApp.Domain.ProductEntity;

namespace SalesWebApp.Infrastructure.Persistence.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IBaseRepository<ProductCategory> ProductCategories { get; private set; }

    public IBaseRepository<Product> Products { get; private set; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        ProductCategories = new BaseRepository<ProductCategory>(_context);
        Products = new BaseRepository<Product>(_context);


    }



    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}