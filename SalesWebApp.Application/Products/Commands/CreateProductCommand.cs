using ErrorOr;
using MediatR;
using SalesWebApp.Application.Abstractions.Repositories;
using SalesWebApp.Domain.Common.DomainErrors;
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
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Product.Create(
            request.Name,
            request.Description,
            request.ProjectOwnerPrice,
            request.SalesmanPrice,
            request.CustomerPrice,
            request.Quantity,
            request.CategoryId,
            request.IsAvailable,
            request.ProductSpecifications,
            request.Thumbnail
        );



        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();
        return product;

    }
}
