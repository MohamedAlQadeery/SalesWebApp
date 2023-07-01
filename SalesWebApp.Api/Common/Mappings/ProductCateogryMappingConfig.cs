
using Azure.Core;
using Mapster;
using SalesWebApp.Api.Contracts.ProductCategory;
using SalesWebApp.Api.Contracts.ProductCategory.Request;
using SalesWebApp.Application.ProductCategories.Commands;
using SalesWebApp.Domain.ProductCategoryEntity;
using SalesWebApp.Domain.ProductEntity;

namespace DinnerNet.Api.Common.Mappings;

public class ProductCateogryMappingConfig : IRegister
{

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateProductCategoryRequest, CreateProductCategoryCommad>();
        config.NewConfig<(UpdateProductCategoryRequest Request, int id), UpdateProductCategoryCommand>()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest, src => src.Request);


        config.NewConfig<ProductCategory, ProductCategoryResponse>()
            .Map(dest => dest.ProductsIds, src => src.Products.Select(x => x.Id).ToList());
        ;

    }
}
