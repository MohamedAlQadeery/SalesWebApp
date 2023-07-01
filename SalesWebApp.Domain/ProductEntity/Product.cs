using ErrorOr;
using SalesWebApp.Domain.Common.DomainErrors;
using SalesWebApp.Domain.Common.Entities;
using SalesWebApp.Domain.Common.ValueObjects;
using SalesWebApp.Domain.ProductCategoryEntity;
using SalesWebApp.Domain.ProductEntity.Entities;

namespace SalesWebApp.Domain.ProductEntity;
public class Product : BaseEntity<int>
{
    private readonly List<ProductSpecification> _productSpecifications = new();
    private readonly List<ProductAttachments> _productAttachments = new();
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public Price ProjectOwnerPrice { get; private set; } = null!;
    public Price SalesmanPrice { get; private set; } = null!;
    public Price CustomerPrice { get; private set; } = null!;

    public string Thumbnail { get; private set; }


    public IReadOnlyCollection<ProductSpecification> ProductSpecifications => _productSpecifications.AsReadOnly();
    public IReadOnlyCollection<ProductAttachments> ProductAttachments => _productAttachments.AsReadOnly();



    public int Quantity { get; private set; }
    public int CategoryId { get; private set; }
    public ProductCategory Category { get; private set; }

    public bool IsAvailable { get; private set; } = true;

    //Empty constructor for EF Core
    private Product()
    {
    }


    //constuctor must have at least on product speicfication
    private Product(
        string name,
        string description,
        Price projectOwnerPrice,
        Price salesmanPrice,
        Price customerPrice,
        int quantity,
        int categoryId,
        bool isAvailable,
        string thumbnail,
        List<ProductSpecification> productSpecifications)
    {
        Name = name;
        Description = description;
        ProjectOwnerPrice = projectOwnerPrice;
        SalesmanPrice = salesmanPrice;
        CustomerPrice = customerPrice;
        Quantity = quantity;
        CategoryId = categoryId;
        IsAvailable = isAvailable;
        _productSpecifications.AddRange(productSpecifications);
        Thumbnail = thumbnail;
    }



    public static ErrorOr<Product> Create(
        string name,
        string description,
        Price projectOwnerPrice,
        Price salesmanPrice,
        Price customerPrice,
        int quantity,
        int categoryId,
        bool isAvailable,
        List<ProductSpecification> productSpecifications,
        string thumbnail)
    {
        if (!productSpecifications.Any())
        {
            return Errors.Product.MustHaveSpecification;
        }

        var product = new Product(
            name,
            description,
            projectOwnerPrice,
            salesmanPrice,
            customerPrice,
            quantity,
            categoryId,
            isAvailable,
            thumbnail,
            productSpecifications
            );


        return product;
    }

    public void Update(
        string name,
        string description,
        Price projectOwnerPrice,
        Price salesmanPrice,
        Price customerPrice,
        int quantity,
        int categoryId,
        bool isAvailable, string? thumbnail)
    {
        Name = name;
        Description = description;
        ProjectOwnerPrice = projectOwnerPrice;
        SalesmanPrice = salesmanPrice;
        CustomerPrice = customerPrice;
        Quantity = quantity;
        CategoryId = categoryId;
        IsAvailable = isAvailable;
        UpdatedDateTime = DateTime.Now;
        //if thumbnail is null, then do not update it
        Thumbnail = thumbnail ?? Thumbnail;
    }

    public void AddProductSpecification(ProductSpecification productSpecification)
    {
        _productSpecifications.Add(productSpecification);
    }

    public void RemoveProductSpecification(ProductSpecification productSpecification)
    {
        _productSpecifications.Remove(productSpecification);
    }

    public void AddProductAttachment(ProductAttachments productAttachment)
    {
        _productAttachments.Add(productAttachment);
    }

    public void RemoveProductAttachment(ProductAttachments productAttachment)
    {
        _productAttachments.Remove(productAttachment);
    }






}