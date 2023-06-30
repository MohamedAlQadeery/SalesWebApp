using System.Reflection;
using FluentValidation;
using SalesWebApp.Api.Contracts.ProductCategory.Validator;

namespace SalesWebApp.Api.Extensions;

public static class ValidatonFilterExtension
{
    public static IServiceCollection AddValidationFilter(this IServiceCollection services)
    {
        //services.AddValidatorsFromAssembly(typeof(CreateProductCategoryValidator).Assembly);
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}