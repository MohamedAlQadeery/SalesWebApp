using ErrorOr;
using MediatR;
using SalesWebApp.Application.Abstractions.Repositories;
using SalesWebApp.Domain.ProductCategoryEntity;

namespace SalesWebApp.Application.ProductCategories.Commands;

public record CreateProductCategoryCommad(string Name, string Description, string? Image = null)
: IRequest<ErrorOr<ProductCategory>>;

public class CreateProductCategoryCommadHandler : IRequestHandler<CreateProductCategoryCommad, ErrorOr<ProductCategory>>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductCategoryCommadHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<ProductCategory>> Handle(CreateProductCategoryCommad request, CancellationToken cancellationToken)
    {
        var productCategory = ProductCategory.Create(request.Name, request.Description, request.Image);
        await _unitOfWork.ProductCategories.AddAsync(productCategory);
        await _unitOfWork.SaveChangesAsync();

        return productCategory;

    }
}
