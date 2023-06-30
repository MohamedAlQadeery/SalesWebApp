using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesWebApp.Api.Abstractions;
using SalesWebApp.Api.Common.Validation;
using SalesWebApp.Api.Contracts.ProductCategory.Request;
using SalesWebApp.Api.Contracts.ProductCategory.Validator;
using SalesWebApp.Application.ProductCategories.Commands;
using SalesWebApp.Application.ProductCategories.Commands.DeleteProductCategory;
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
        categories.MapGet("/{id}", GetProductCategoryById).WithName("GetProductCategoryById");
        categories.MapPut("/{id}", UpdateProductCategory);
        categories.MapDelete("/{id}", DeleteProductCategory);
    }



    private async Task<IResult> CreateProductCategory(HttpContext context, ISender mediatr, IMapper mapper, CreateProductCategoryRequest request)
    {
        var command = mapper.Map<CreateProductCategoryCommad>(request);
        var productCategory = await mediatr.Send(command);

        return productCategory.Match(
              productCategory => Results.CreatedAtRoute("GetProductCategoryById", new { id = productCategory.Id }, productCategory),
              //productCategory => TypedResults.Ok(productCategory),
              errors => ResultsProblem(context, errors)
          );
    }

    //update product category
    private async Task<IResult> UpdateProductCategory(HttpContext context, IMapper mapper,
    ISender mediatr, int id, UpdateProductCategoryRequest request)
    {
        var command = mapper.Map<UpdateProductCategoryCommand>((request, id));
        var productCategory = await mediatr.Send(command);

        return productCategory.Match(
              //productCategory => Results.CreatedAtRoute("GetById", new { id = productCategory.Id }, productCategory),
              productCategory => TypedResults.Ok(productCategory),
              errors => ResultsProblem(context, errors)
          );
    }


    private async Task<IResult> DeleteProductCategory(HttpContext context,
    ISender mediatr, int id)
    {
        var command = new DeleteProductCategoryCommand(id);
        var deleteResult = await mediatr.Send(command);

        return deleteResult.Match(
              //productCategory => Results.CreatedAtRoute("GetById", new { id = productCategory.Id }, productCategory),
              productCategory => TypedResults.NoContent(),
              errors => ResultsProblem(context, errors)
          );
    }



    private async Task<IResult> GetAllProductCategories(ISender mediatr)
    {
        var catgories = await mediatr.Send(new GetAllProductCategoriesQuery());

        return TypedResults.Ok(catgories);
    }

    private async Task<IResult> GetProductCategoryById(HttpContext context, ISender mediatr, int id)
    {
        var categoryResult = await mediatr.Send(new GetProductCategoryByIdQuery(id));

        return categoryResult.Match(
            category => TypedResults.Ok(category),
            errors => ResultsProblem(context, errors)
        );
    }
}
