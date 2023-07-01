using MediatR;
using SalesWebApp.Application.Abstractions.Repositories;
using SalesWebApp.Domain.ProductCategoryEntity;

namespace SalesWebApp.Application.ProductCategories.Queries;
public record GetAllProductCategoriesQuery() : IRequest<IReadOnlyList<ProductCategory>>;

public class GetAllProductCategoriesQueryHandler : IRequestHandler<GetAllProductCategoriesQuery, IReadOnlyList<ProductCategory>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllProductCategoriesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IReadOnlyList<ProductCategory>> Handle(GetAllProductCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.ProductCategories.GetAllAsync(new string[] { "Products" });
    }
}
