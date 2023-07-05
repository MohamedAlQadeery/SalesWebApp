using SalesWebApp.Infrastructure;
using SalesWebApp.Application;
using SalesWebApp.Api.Extensions;
using SalesWebApp.Api;
using SalesWebApp.Infrastructure.Persistence;

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


    // Initialise and seed database
    using (var scope = app.Services.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<AppDbContextInitialiser>();
        await initialiser.InitialiseAsync();
        await initialiser.SeedAsync();
    }
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.RegisterEndpointDefinitions();




    app.Run();
}

