using ErrorOr;
using MediatR;
using SalesWebApp.Domain.Common.ValueObjects;
using SalesWebApp.Domain.ProductEntity;
using SalesWebApp.Domain.ProductEntity.Entities;

namespace SalesWebApp.Application.Products.Commands;

public record CreateProductCommand(
    string Name,
    string Description,
    Price ProjectOwnerPrice,
    Price SalesmanPrice,
    Price CustomerPrice,
    int Quantity,
    int CategoryId,
    bool IsAvailable,
    List<ProductSpecification> ProductSpecifications,
    string Thumbnail
) : IRequest<ErrorOr<Product>>;


public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<Product>>
{
    public Task<ErrorOr<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
