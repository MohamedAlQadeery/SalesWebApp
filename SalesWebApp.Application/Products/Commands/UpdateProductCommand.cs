using ErrorOr;
using MediatR;
using SalesWebApp.Application.Abstractions.Repositories;
using SalesWebApp.Domain.ProductEntity;
using SalesWebApp.Domain.Common.DomainErrors;
using SalesWebApp.Domain.Common.ValueObjects;

namespace SalesWebApp.Application.Products.Commands;
public record UpdateProductCommand(
    int Id,
    string Name,
    string Description,
    PriceCommand ProjectOwnerPrice,
    PriceCommand SalesmanPrice,
    PriceCommand CustomerPrice,
    int Quantity,
    int CategoryId,
    bool IsAvailable,
    string? Thumbnail
) : IRequest<ErrorOr<Product>>;


public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ErrorOr<Product>>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<Product>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id);
        if (product is null)
        {
            return Errors.Product.ProductNotFound;
        }

        var category = await _unitOfWork.ProductCategories.GetByIdAsync(request.CategoryId);
        if (category is null)
        {
            return Errors.Product.CategoryNotFound;
        }

        //manage prices
        var projectOwnerPrice = Price.Create(request.ProjectOwnerPrice.Value, request.ProjectOwnerPrice.Currency);
        var salesmanPrice = Price.Create(request.SalesmanPrice.Value, request.SalesmanPrice.Currency);
        var customerPrice = Price.Create(request.CustomerPrice.Value, request.CustomerPrice.Currency);

        product.Update(
            name: request.Name,
            description: request.Description,
            projectOwnerPrice: projectOwnerPrice,
            salesmanPrice: salesmanPrice,
            customerPrice: customerPrice,
            quantity: request.Quantity,
            categoryId: request.CategoryId,
            isAvailable: request.IsAvailable,
            thumbnail: request.Thumbnail ?? product.Thumbnail
        );

        _unitOfWork.Products.Update(product);
        await _unitOfWork.SaveChangesAsync();

        return product; ;



    }
}