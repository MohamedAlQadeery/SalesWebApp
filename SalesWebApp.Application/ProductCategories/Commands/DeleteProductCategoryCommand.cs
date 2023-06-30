using ErrorOr;
using MediatR;
using SalesApp.Domain.Common.DomainErrors;
using SalesWebApp.Application.Abstractions.Repositories;

namespace SalesWebApp.Application.ProductCategories.Commands.DeleteProductCategory;
public record DeleteProductCategoryCommand(int Id) : IRequest<ErrorOr<Unit>>;


public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand, ErrorOr<Unit>>
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    public DeleteProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }
    public async Task<ErrorOr<Unit>> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var productTodelete = await _productCategoryRepository.GetByIdAsync(request.Id);
        if (productTodelete is null) { return Errors.Common.NotFound; }

        await _productCategoryRepository.DeleteAsync(productTodelete);
        return Unit.Value;


    }
}
