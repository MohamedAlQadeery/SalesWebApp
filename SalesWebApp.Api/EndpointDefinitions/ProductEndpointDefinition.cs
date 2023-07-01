using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesWebApp.Api.Abstractions;
using SalesWebApp.Api.Common.Validation;
using SalesWebApp.Api.Contracts.ProductCategory.Request;
using SalesWebApp.Api.Contracts.ProductCategory.Validator;
using SalesWebApp.Api.Contracts.Products;
using SalesWebApp.Application.ProductCategories.Commands;
using SalesWebApp.Application.ProductCategories.Commands.DeleteProductCategory;
using SalesWebApp.Application.ProductCategories.Queries;
using SalesWebApp.Application.Products.Commands;

namespace SalesWebApp.Api.EndpointDefinitions;
public class ProductEndpointDefinition : BaseEndpointDefinition, IEndpointDefintion
{
    public void RegisterEndpoints(WebApplication app)
    {
        var products = app.MapGroup("/api/products");
        products.MapPost("/", CreateProduct);
        // .AddEndpointFilter<ValidationFilter<CreateProductCategoryRequest>>();

        products.MapGet("", GetAllProduct);
        // categories.MapGet("/{id}", GetProductCategoryById).WithName("GetProductCategoryById");
        // categories.MapPut("/{id}", UpdateProductCategory);
        // categories.MapDelete("/{id}", DeleteProductCategory);
    }



    private async Task<IResult> CreateProduct(HttpContext context, ISender mediatr, IMapper mapper,
    CreateProductRequest request)
    {
        var command = mapper.Map<CreateProductCommand>(request);
        var productResult = await mediatr.Send(command);

        return productResult.Match(
              // productCategory => Results.CreatedAtRoute("GetProductCategoryById", new { id = productCategory.Id }, productCategory),
              product => TypedResults.Ok(mapper.Map<ProductResponse>(product)),
              errors => ResultsProblem(context, errors)
          );
    }

    //update product category



    private async Task<IResult> GetAllProduct(ISender mediatr, IMapper mapper)
    {
        var products = await mediatr.Send(new GetAllProductsQuery());

        return TypedResults.Ok(mapper.Map<List<ProductResponse>>(products));
    }


}
