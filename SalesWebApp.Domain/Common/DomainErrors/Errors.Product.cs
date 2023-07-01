using ErrorOr;
namespace SalesWebApp.Domain.Common.DomainErrors;
public static partial class Errors
{
    public static class Product
    {

        public static Error MustHaveSpecification =>
         Error.Validation(code: "MustHaveSpecification", description: "Product must have at least one specification");
    }
}