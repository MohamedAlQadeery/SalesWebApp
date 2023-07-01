
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
        config.NewConfig<(UpdateProductRequest request, int id), UpdateProductCommand>()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest, src => src.request);


    }
}
