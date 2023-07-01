using ErrorOr;
using MediatR;
using SalesWebApp.Application.Abstractions.Repositories;
using SalesWebApp.Domain.ProductEntity;
using SalesWebApp.Domain.Common.DomainErrors;

public record GetProductById(int Id) : IRequest<ErrorOr<Product>>;


public class GetProductByIdHandler : IRequestHandler<GetProductById, ErrorOr<Product>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetProductByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<Product>> Handle(GetProductById request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id);
        if (product is null) { return Errors.Product.ProductNotFound; }

        return product;
    }
}
