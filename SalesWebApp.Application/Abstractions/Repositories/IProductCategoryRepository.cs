using SalesWebApp.Domain.ProductCategoryEntity;

namespace SalesWebApp.Application.Abstractions.Repositories;

public interface IProductCategoryRepository
{
    Task<ProductCategory> GetByIdAsync(int id);
    Task<IReadOnlyList<ProductCategory>> GetAllAsync();
    Task<ProductCategory> AddAsync(ProductCategory productCategory);
    Task<ProductCategory> UpdateAsync(ProductCategory productCategory);
    Task DeleteAsync(ProductCategory productCategory);
}