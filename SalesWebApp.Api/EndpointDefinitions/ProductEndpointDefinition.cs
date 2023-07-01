using MapsterMapper;
using MediatR;
using SalesWebApp.Api.Abstractions;
using SalesWebApp.Api.Contracts.Products;
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
        products.MapGet("/{id}", GetProductById).WithName("GetProductById");
        products.MapPut("/{id}", UpdateProduct);
        products.MapDelete("/{id}", DeleteProductCategory);
    }



    private async Task<IResult> CreateProduct(HttpContext context, ISender mediatr, IMapper mapper,
    CreateProductRequest request)
    {
        var command = mapper.Map<CreateProductCommand>(request);
        var productResult = await mediatr.Send(command);

        return productResult.Match(
               product => Results.CreatedAtRoute("GetProductById", new { id = product.Id }, product),
              // product => TypedResults.Ok(mapper.Map<ProductResponse>(product)),
              errors => ResultsProblem(context, errors)
          );
    }

    //update product category



    private async Task<IResult> GetAllProduct(ISender mediatr, IMapper mapper)
    {
        var products = await mediatr.Send(new GetAllProductsQuery());

        return TypedResults.Ok(mapper.Map<List<ProductResponse>>(products));
    }


    private async Task<IResult> UpdateProduct(HttpContext context, ISender mediatr,
     IMapper mapper, int id, UpdateProductRequest request)
    {
        var updateCommand = mapper.Map<UpdateProductCommand>((request, id));
        var productResult = await mediatr.Send(updateCommand);

        return productResult.Match(
              //productCategory => Results.CreatedAtRoute("GetById", new { id = productCategory.Id }, productCategory),
              product => TypedResults.Ok(mapper.Map<ProductResponse>(product)),
              errors => ResultsProblem(context, errors)
          );
    }

    private async Task<IResult> GetProductById(HttpContext content, ISender mediatr, IMapper mapper, int id)
    {
        var product = await mediatr.Send(new GetProductById(id));

        return product.Match(
              product => TypedResults.Ok(mapper.Map<ProductResponse>(product)),
              errors => ResultsProblem(content, errors)
          );
    }

    private async Task<IResult> DeleteProductCategory(HttpContext context, ISender mediatr, int id)
    {
        var result = await mediatr.Send(new DeleteProductCommand(id));

        return result.Match(
              unit => Results.NoContent(),
              errors => ResultsProblem(context, errors)
          );
    }


}
