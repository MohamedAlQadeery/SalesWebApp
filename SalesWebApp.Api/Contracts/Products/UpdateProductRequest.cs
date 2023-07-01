namespace SalesWebApp.Api.Contracts.Products;
public record UpdateProductRequest(
    int Id,
    string Name,
    string Description,
    Price ProjectOwnerPrice,
    Price SalesmanPrice,
    Price CustomerPrice,
    int Quantity,
    int CategoryId,
    bool IsAvailable,
    string Thumbnail
);