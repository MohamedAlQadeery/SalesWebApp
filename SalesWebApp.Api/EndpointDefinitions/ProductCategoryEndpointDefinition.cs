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
        app.MapPost("/api/product-categories", async (ISender mediatr, CreateProductCategoryRequest request) =>
           {
               var command = new CreateProductCategoryCommad(request.Name, request.Description, request.Image);
               var productCategory = await mediatr.Send(command);

               return productCategory.Match(
                     //productCategory => Results.CreatedAtRoute("GetById", new { id = productCategory.Id }, productCategory),
                     productCategory => Results.Ok(productCategory),
                     errors => Results.BadRequest()
                 );

           });


        app.MapGet("/api/product-categories", async (ISender mediatr) =>
         {
             var catgories = await mediatr.Send(new GetAllProductCategoriesQuery());

             return Results.Ok(catgories);

         });
    }
}
