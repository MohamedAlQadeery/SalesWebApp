
using Azure.Core;
using Mapster;
using SalesWebApp.Api.Contracts.ProductCategory.Request;
using SalesWebApp.Application.ProductCategories.Commands;

namespace DinnerNet.Api.Common.Mappings;

public class ProductCateogryMappingConfig : IRegister
{

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateProductCategoryRequest, CreateProductCategoryCommad>();
        config.NewConfig<(UpdateProductCategoryRequest Request, int id), UpdateProductCategoryCommand>()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest, src => src.Request);

    }
}
