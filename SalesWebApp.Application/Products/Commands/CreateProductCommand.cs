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
    PriceCommand ProjectOwnerPrice,
    PriceCommand SalesmanPrice,
    PriceCommand CustomerPrice,
    int Quantity,
    int CategoryId,
    bool IsAvailable,
    List<ProductSpecificationCommand> ProductSpecifications,
    string Thumbnail
) : IRequest<ErrorOr<Product>>;


public record PriceCommand(
    decimal Value,
    string Currency
);

public record ProductSpecificationCommand(
    float Weight,
    string WeightUnit,
    float Height,
    float Width,
    string Color
);

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<Product>>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {

        var category = await _unitOfWork.ProductCategories.GetByIdAsync(request.CategoryId);
        if (category is null) { return Errors.Product.CategoryNotFound; }

        //for each product specification create a new ProductSpecification entity
        var productSpecifications = CreateProductSpecifications(request.ProductSpecifications);

        //manage prices
        var projectOwnerPrice = Price.Create(request.ProjectOwnerPrice.Value, request.ProjectOwnerPrice.Currency);
        var salesmanPrice = Price.Create(request.SalesmanPrice.Value, request.SalesmanPrice.Currency);
        var customerPrice = Price.Create(request.CustomerPrice.Value, request.CustomerPrice.Currency);



        var product = Product.Create(
            request.Name,
            request.Description,
            projectOwnerPrice,
            salesmanPrice,
            customerPrice,
            request.Quantity,
            request.CategoryId,
            request.IsAvailable,
            productSpecifications,
            request.Thumbnail
        );



        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();
        return product;

    }

    private List<ProductSpecification> CreateProductSpecifications(List<ProductSpecificationCommand> productSpecifications)
    {
        var productSpecificationsList = new List<ProductSpecification>();
        foreach (var productSpecificationCommand in productSpecifications)
        {
            var productSpecification = ProductSpecification.Create(
                productSpecificationCommand.Weight,
                productSpecificationCommand.WeightUnit,
                productSpecificationCommand.Height,
                productSpecificationCommand.Width,
                productSpecificationCommand.Color
            );
            productSpecificationsList.Add(productSpecification);
        }

        return productSpecificationsList;
    }


}
