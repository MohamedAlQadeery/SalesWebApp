
namespace SalesWebApp.Api.Contracts.Products;

public record CreateProductRequest(
    string Name,
    string Description,
    Price ProjectOwnerPrice,
    Price SalesmanPrice,
    Price CustomerPrice,
    int Quantity,
    int CategoryId,
    bool IsAvailable,
    List<ProductSpecification> ProductSpecifications,
    string Thumbnail
);

public record Price(
    decimal Value,
    string Currency
);

public record ProductSpecification(
    float Weight,
    string WeightUnit,
    float Height,
    float Width,
    string Color
);
