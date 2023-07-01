using SalesWebApp.Domain.ProductCategoryEntity;
using SalesWebApp.Domain.ProductEntity;

namespace SalesWebApp.Application.Abstractions.Repositories;

public interface IUnitOfWork : IDisposable
{
    public IBaseRepository<ProductCategory> ProductCategories { get; }
    public IBaseRepository<Product> Products { get; }


    Task<int> SaveChangesAsync();
}