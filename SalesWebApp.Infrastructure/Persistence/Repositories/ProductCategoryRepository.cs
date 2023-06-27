using Microsoft.EntityFrameworkCore;
using SalesWebApp.Application.Abstractions.Repositories;
using SalesWebApp.Domain.ProductCategory;

namespace SalesWebApp.Infrastructure.Persistence.Repositories;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly AppDbContext _dbContext;

    public ProductCategoryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProductCategory> GetByIdAsync(int id)
    {
        return await _dbContext.ProductCategories.FindAsync(id);
    }

    public async Task<IReadOnlyList<ProductCategory>> GetAllAsync()
    {
        return await _dbContext.ProductCategories.ToListAsync();
    }

    public async Task<ProductCategory> AddAsync(ProductCategory productCategory)
    {
        await _dbContext.ProductCategories.AddAsync(productCategory);
        await _dbContext.SaveChangesAsync();
        return productCategory;
    }

    public async Task<ProductCategory> UpdateAsync(ProductCategory productCategory)
    {
        _dbContext.ProductCategories.Update(productCategory);
        await _dbContext.SaveChangesAsync();
        return productCategory;
    }

    public async Task DeleteAsync(ProductCategory productCategory)
    {
        _dbContext.ProductCategories.Remove(productCategory);
        await _dbContext.SaveChangesAsync();
    }
}