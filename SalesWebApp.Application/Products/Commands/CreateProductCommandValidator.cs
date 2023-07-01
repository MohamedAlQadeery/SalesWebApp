using FluentValidation;

namespace SalesWebApp.Application.Products.Commands;

public class CreateProductCommadValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommadValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        RuleFor(x => x.ProjectOwnerPrice).NotNull();
        RuleFor(x => x.ProjectOwnerPrice.Value).NotEmpty().GreaterThan(0);
        RuleFor(x => x.ProjectOwnerPrice.Currency).NotEmpty().MaximumLength(3);
        RuleFor(x => x.CustomerPrice).NotNull();
        RuleFor(x => x.CustomerPrice.Value).NotEmpty().GreaterThan(0);
        RuleFor(x => x.CustomerPrice.Currency).NotEmpty().MaximumLength(3);
        RuleFor(x => x.SalesmanPrice).NotNull();
        RuleFor(x => x.SalesmanPrice.Value).NotEmpty().GreaterThan(0);
        RuleFor(x => x.SalesmanPrice.Currency).NotEmpty().MaximumLength(3);
        RuleFor(x => x.CategoryId).NotEmpty();
        RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0);
        RuleFor(x => x.ProductSpecifications).NotEmpty().Must(x => x.Count > 0);







    }
}