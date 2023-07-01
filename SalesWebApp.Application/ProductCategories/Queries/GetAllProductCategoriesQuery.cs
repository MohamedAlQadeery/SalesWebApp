using MediatR;
using SalesWebApp.Application.Abstractions.Repositories;
using SalesWebApp.Domain.ProductCategoryEntity;

namespace SalesWebApp.Application.ProductCategories.Queries;
public record GetAllProductCategoriesQuery() : IRequest<IReadOnlyList<ProductCategory>>;

public class GetAllProductCategoriesQueryHandler : IRequestHandler<GetAllProductCategoriesQuery, IReadOnlyList<ProductCategory>>
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    public GetAllProductCategoriesQueryHandler(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }
    public async Task<IReadOnlyList<ProductCategory>> Handle(GetAllProductCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _productCategoryRepository.GetAllAsync();
    }
}
