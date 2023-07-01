using SalesWebApp.Domain.ProductEntity.Entities;

namespace SalesWebApp.Api.Contracts.Products;

public record ProductResponse(
    int Id,
    string Name,
    string Description,
    Price ProjectOwnerPrice,
    Price SalesmanPrice,
    Price CustomerPrice,
    string Thumbnail,
    int Quantity,
    int CategoryId,
    bool IsAvailable,
    List<ProductSpecification> ProductSpecifications,
    List<ProductAttachments> ProductAttachments
);

public record ProductAttachments(
    string Url,
    bool IsImage
);