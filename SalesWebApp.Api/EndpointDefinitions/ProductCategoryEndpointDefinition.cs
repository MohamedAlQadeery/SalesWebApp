using MediatR;
using SalesWebApp.Api.Abstractions;
using SalesWebApp.Api.Contracts.ProductCategory.Request;
using SalesWebApp.Application.ProductCategories.Commands;
using SalesWebApp.Application.ProductCategories.Queries;

namespace SalesWebApp.Api.EndpointDefinitions;
public class ProductCategoryEndpointDefinition : IEndpointDefintion
{
    public void RegisterEndpoints(WebApplication app)
    {
        var categories = app.MapGroup("/api/product-categories");
        categories.MapPost("/", CreateProductCategory);
        categories.MapGet("", GetAllProductCategories);
    }


    private async Task<IResult> CreateProductCategory(ISender mediatr, CreateProductCategoryRequest request)
    {
        var command = new CreateProductCategoryCommad(request.Name, request.Description, request.Image);
        var productCategory = await mediatr.Send(command);

        return productCategory.Match(
              //productCategory => Results.CreatedAtRoute("GetById", new { id = productCategory.Id }, productCategory),
              productCategory => TypedResults.Ok(productCategory),
              errors => Results.BadRequest()
          );
    }

    private async Task<IResult> GetAllProductCategories(ISender mediatr)
    {
        var catgories = await mediatr.Send(new GetAllProductCategoriesQuery());

        return TypedResults.Ok(catgories);
    }
}
