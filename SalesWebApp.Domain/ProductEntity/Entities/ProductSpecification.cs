
using SalesWebApp.Domain.Common.Entities;

namespace SalesWebApp.Domain.ProductEntity.Entities;

public sealed class ProductSpecification : BaseEntity<int>
{
    public float Weight { get; private set; }
    public string WeightUnit { get; private set; } = null!;
    public float Height { get; private set; }
    public float Width { get; private set; }

    public string Color { get; private set; } = null!;

    //Empty constructor for EF Core
    private ProductSpecification()
    {
    }

    private ProductSpecification(
        float weight,
        string weightUnit,
        float height,
        float width,
        string color)
    {
        Weight = weight;
        WeightUnit = weightUnit;
        Height = height;
        Width = width;
        Color = color;
    }


    public static ProductSpecification Create(
        float weight,
        string weightUnit,
        float height,
        float width,
        string color)
    {
        var productSpecification = new ProductSpecification(
            weight,
            weightUnit,
            height,
            width,
            color);

        return productSpecification;
    }
}