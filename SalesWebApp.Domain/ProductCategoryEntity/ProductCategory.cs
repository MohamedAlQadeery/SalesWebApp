using SalesWebApp.Domain.Common.Entities;
using SalesWebApp.Domain.ProductEntity;

namespace SalesWebApp.Domain.ProductCategoryEntity;

public sealed class ProductCategory : BaseEntity<int>
{

    private readonly List<Product> _products = new();

    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public string? Image { get; private set; }

    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();



    private ProductCategory()
    {
    }

    private ProductCategory(string name, string description, string? image)
    {
        Name = name;
        Description = description;
        Image = image;
    }

    public static ProductCategory Create(string name, string description, string? image)
    {
        return new ProductCategory(name, description, image);
    }

    public void Update(string name, string description, string? image)
    {
        Name = name;
        Description = description;
        Image = image ?? Image;
        UpdatedDateTime = DateTime.Now;
    }









}