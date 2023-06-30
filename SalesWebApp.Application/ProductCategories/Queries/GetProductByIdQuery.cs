using ErrorOr;
using MediatR;
using SalesWebApp.Application.Abstractions.Repositories;
using SalesApp.Domain.Common.DomainErrors;

using SalesWebApp.Domain.ProductCategory;

namespace SalesWebApp.Application.ProductCategories.Queries;
public record GetProductCategoryByIdQuery(int Id) : IRequest<ErrorOr<ProductCategory>>;


public class GetProductCategoryByIdQueryHandler : IRequestHandler<GetProductCategoryByIdQuery, ErrorOr<ProductCategory>>
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    public GetProductCategoryByIdQueryHandler(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }
    public async Task<ErrorOr<ProductCategory>> Handle(GetProductCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var productCategory = await _productCategoryRepository.GetByIdAsync(request.Id);

        if (productCategory is null) { return Errors.Common.NotFound; }
        return productCategory;
    }
}
