using SalesWebApp.Infrastructure;
using SalesWebApp.Application;
using MediatR;
using SalesWebApp.Api.Contracts.ProductCategory.Request;
using SalesWebApp.Application.ProductCategories.Commands;
using SalesWebApp.Application.ProductCategories.Queries;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);

}
var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
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



    app.Run();
}

