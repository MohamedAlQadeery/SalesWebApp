using ErrorOr;
using MediatR;
using SalesWebApp.Application.Abstractions.Repositories;
using SalesWebApp.Domain.ProductCategory;

namespace SalesWebApp.Application.ProductCategories.Commands;

public record CreateProductCategoryCommad(string Name, string Description, string? Image = null)
: IRequest<ErrorOr<ProductCategory>>;

public class CreateProductCategoryCommadHandler : IRequestHandler<CreateProductCategoryCommad, ErrorOr<ProductCategory>>
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    public CreateProductCategoryCommadHandler(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<ErrorOr<ProductCategory>> Handle(CreateProductCategoryCommad request, CancellationToken cancellationToken)
    {
        var productCategory = ProductCategory.Create(request.Name, request.Description, request.Image);
        await _productCategoryRepository.AddAsync(productCategory);
        return productCategory;

    }
}
