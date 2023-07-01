using SalesWebApp.Domain.Common.Entities;

namespace SalesWebApp.Domain.ProductCategoryEntity;

public sealed class ProductId : EntityId<Guid>
{

    // for ef core
    public ProductId()
    {

    }

    private ProductId(Guid value) : base(value)
    {
    }

    public static ProductId Create(Guid value)
    {
        return new ProductId(value);
    }

    public static ProductId CreateUnique()
    {
        return new ProductId(Guid.NewGuid());
    }





}