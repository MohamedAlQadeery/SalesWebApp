using ErrorOr;
using MediatR;
using SalesWebApp.Application.Abstractions.Repositories;
using SalesWebApp.Domain.Common.DomainErrors;

using SalesWebApp.Domain.ProductCategoryEntity;

namespace SalesWebApp.Application.ProductCategories.Queries;
public record GetProductCategoryByIdQuery(int Id) : IRequest<ErrorOr<ProductCategory>>;


public class GetProductCategoryByIdQueryHandler : IRequestHandler<GetProductCategoryByIdQuery, ErrorOr<ProductCategory>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetProductCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<ProductCategory>> Handle(GetProductCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var productCategory = await _unitOfWork.ProductCategories.GetByIdAsync(request.Id);

        if (productCategory is null) { return Errors.Common.NotFound; }
        return productCategory;
    }
}
