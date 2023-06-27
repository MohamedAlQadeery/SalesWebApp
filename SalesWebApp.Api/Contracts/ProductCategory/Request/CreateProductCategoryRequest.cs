namespace SalesWebApp.Api.Contracts.ProductCategory.Request;

public record CreateProductCategoryRequest(string Name, string Description, string? Image);
