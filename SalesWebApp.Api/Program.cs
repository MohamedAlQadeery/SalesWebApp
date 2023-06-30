using SalesWebApp.Infrastructure;
using SalesWebApp.Application;
using MediatR;
using SalesWebApp.Api.Contracts.ProductCategory.Request;
using SalesWebApp.Application.ProductCategories.Commands;
using SalesWebApp.Application.ProductCategories.Queries;
using SalesWebApp.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddValidationFilter();
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
    app.RegisterEndpointDefinitions();




    app.Run();
}

