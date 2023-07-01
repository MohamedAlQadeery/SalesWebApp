using ErrorOr;
using MediatR;
using SalesWebApp.Domain.Common.DomainErrors;
using SalesWebApp.Application.Abstractions.Repositories;
using SalesWebApp.Domain.ProductCategoryEntity;

namespace SalesWebApp.Application.ProductCategories.Commands;

public record UpdateProductCategoryCommand(int Id, string Name, string Description, string? Image = null) :
IRequest<ErrorOr<ProductCategory>>;

public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, ErrorOr<ProductCategory>>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateProductCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<ProductCategory>> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryToUpdate = await _unitOfWork.ProductCategories.GetByIdAsync(request.Id);
        if (categoryToUpdate is null)
        {
            return Errors.Common.NotFound;
        }

        categoryToUpdate.Update(request.Name, request.Description, request.Image ?? null);

        var updatedCategory = _unitOfWork.ProductCategories.Update(categoryToUpdate);
        await _unitOfWork.SaveChangesAsync();

        return updatedCategory;
    }
}
