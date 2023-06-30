using SalesWebApp.Infrastructure;
using SalesWebApp.Application;
using SalesWebApp.Api.Extensions;
using SalesWebApp.Api;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
    .AddPresentaion()
    .AddApplication().AddInfrastructure(builder.Configuration);
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

