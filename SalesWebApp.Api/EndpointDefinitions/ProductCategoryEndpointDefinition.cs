using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesWebApp.Api.Abstractions;
using SalesWebApp.Api.Common.Validation;
using SalesWebApp.Api.Contracts.ProductCategory.Request;
using SalesWebApp.Api.Contracts.ProductCategory.Validator;
using SalesWebApp.Application.ProductCategories.Commands;
using SalesWebApp.Application.ProductCategories.Queries;

namespace SalesWebApp.Api.EndpointDefinitions;
public class ProductCategoryEndpointDefinition : BaseEndpointDefinition, IEndpointDefintion
{
    public void RegisterEndpoints(WebApplication app)
    {
        var categories = app.MapGroup("/api/product-categories");
        categories.MapPost("/", CreateProductCategory);
        // .AddEndpointFilter<ValidationFilter<CreateProductCategoryRequest>>();

        categories.MapGet("", GetAllProductCategories);
        // categories.MapGet("/{id}", GetProductCategoryById);
        categories.MapPut("/{id}", UpdateProductCategory);
    }



    private async Task<IResult> CreateProductCategory(HttpContext context, ISender mediatr, CreateProductCategoryRequest request)
    {
        var command = new CreateProductCategoryCommad(request.Name, request.Description, request.Image);
        var productCategory = await mediatr.Send(command);

        return productCategory.Match(
              //productCategory => Results.CreatedAtRoute("GetById", new { id = productCategory.Id }, productCategory),
              productCategory => TypedResults.Ok(productCategory),
              errors => ResultsProblem(context, errors)
          );
    }

    //update product category
    private async Task<IResult> UpdateProductCategory(HttpContext context,
    ISender mediatr, int id, UpdateProductCategoryRequest request)
    {
        var command = new UpdateProductCategoryCommand(id, request.Name, request.Description, request.Image);
        var productCategory = await mediatr.Send(command);

        return productCategory.Match(
              //productCategory => Results.CreatedAtRoute("GetById", new { id = productCategory.Id }, productCategory),
              productCategory => TypedResults.Ok(productCategory),
              errors => ResultsProblem(context, errors)
          );
    }


    private async Task<IResult> GetAllProductCategories(ISender mediatr)
    {
        var catgories = await mediatr.Send(new GetAllProductCategoriesQuery());

        return TypedResults.Ok(catgories);
    }
}
