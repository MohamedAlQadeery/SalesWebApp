using ErrorOr;
using MediatR;
using SalesWebApp.Application.Abstractions.Repositories;
using SalesWebApp.Domain.Common.DomainErrors;

namespace SalesWebApp.Application.Products.Commands;

public record DeleteProductCommand(int Id) : IRequest<ErrorOr<Unit>>;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ErrorOr<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id);
        if (product is null) { return Errors.Product.ProductNotFound; }

        _unitOfWork.Products.Delete(product);
        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;

    }
}
