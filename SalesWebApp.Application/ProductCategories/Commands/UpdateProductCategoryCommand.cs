using ErrorOr;
using MediatR;
using SalesApp.Domain.Common.DomainErrors;
using SalesWebApp.Application.Abstractions.Repositories;
using SalesWebApp.Domain.ProductCategory;

namespace SalesWebApp.Application.ProductCategories.Commands;

public record UpdateProductCategoryCommand(int Id, string Name, string Description, string? Image = null) :
IRequest<ErrorOr<ProductCategory>>;

public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, ErrorOr<ProductCategory>>
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    public UpdateProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }
    public async Task<ErrorOr<ProductCategory>> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryToUpdate = await _productCategoryRepository.GetByIdAsync(request.Id);
        if (categoryToUpdate is null)
        {
            return Errors.Common.NotFound;
        }

        categoryToUpdate.Update(request.Name, request.Description, request.Image ?? null);

        var updatedCategory = await _productCategoryRepository.UpdateAsync(categoryToUpdate);

        return updatedCategory;
    }
}
