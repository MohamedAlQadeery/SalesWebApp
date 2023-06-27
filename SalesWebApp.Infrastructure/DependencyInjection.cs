using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using SalesWebApp.Application.ProductCategories.Abstractions;
using SalesWebApp.Infrastructure.Persistence.Repositories;

namespace SalesWebApp.Infrastructure;

public static class DependencyInjection
{


    public static IServiceCollection AddInfrastructure(
       this IServiceCollection services
    //    ConfigurationManager configuration
    )
    {
        // services.AddDbContext<AppDbContext>(opt =>
        // {
        //     opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        // });

        // services.AddScoped<AppDbContextInitialiser>();

        // // Add Identity services
        // services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        // {
        //     options.Password.RequireDigit = false;
        //     options.Password.RequireLowercase = false;
        //     options.Password.RequireUppercase = false;
        //     options.Password.RequireNonAlphanumeric = false;
        //     options.Password.RequiredLength = 6;
        //     options.SignIn.RequireConfirmedEmail = false;
        // })
        // .AddEntityFrameworkStores<AppDbContext>()
        // .AddDefaultTokenProviders();

        services
            //  .AddAuth(configuration)
            .AddPersistance();

        return services;
    }
    public static IServiceCollection AddPersistance(
       this IServiceCollection services)
    {

        //services.AddScoped<PublishDomainEventsInterceptor>();
        services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();


        return services;
    }



    // public static IServiceCollection AddAuth(
    //         this IServiceCollection services,
    //         ConfigurationManager configuration)
    // {
    //     var jwtSettings = new JwtSettings();
    //     configuration.Bind(JwtSettings.SectionName, jwtSettings);

    //     services.AddSingleton(Options.Create(jwtSettings));
    //     services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

    //     services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
    //         .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
    //         {
    //             ValidateIssuer = true,
    //             ValidateAudience = true,
    //             ValidateLifetime = true,
    //             ValidateIssuerSigningKey = true,
    //             ValidIssuer = jwtSettings.Issuer,
    //             ValidAudience = jwtSettings.Audience,
    //             IssuerSigningKey = new SymmetricSecurityKey(
    //                 Encoding.UTF8.GetBytes(jwtSettings.Secret)),
    //         });

    //     return services;
    // }
}