
using Azure.Core;
using Mapster;
using SalesWebApp.Api.Contracts.ProductCategory.Request;
using SalesWebApp.Api.Contracts.Products;
using SalesWebApp.Application.ProductCategories.Commands;
using SalesWebApp.Application.Products.Commands;

namespace DinnerNet.Api.Common.Mappings;

public class ProductMappingConfig : IRegister
{

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateProductRequest, CreateProductCommand>();


    }
}
