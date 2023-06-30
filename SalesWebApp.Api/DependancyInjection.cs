
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SalesWebApp.Api.Abstractions;
using SalesWebApp.Api.Common.Errors;
using SalesWebApp.Api.Common.Services;
using SalesWebApp.Api.Extensions;

namespace SalesWebApp.Api;

public static class DependancyInjection
{

    public static IServiceCollection AddPresentaion(this IServiceCollection services)
    {
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddValidationFilter();
        services.AddSingleton<ProblemDetailsFactory, SalesAppProblemDetailsFactory>();
        services.AddScoped<IImageService, ImageService>();


        return services;
    }
}