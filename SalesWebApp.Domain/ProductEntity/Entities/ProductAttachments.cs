
using SalesWebApp.Domain.Common.Entities;

namespace SalesWebApp.Domain.ProductEntity.Entities;

public sealed class ProductAttachments : BaseEntity<int>
{
    public string Url { get; private set; }
    public bool IsImage { get; set; } = true;

    //Empty constructor for EF Core
    private ProductAttachments()
    {
    }

    private ProductAttachments(
        string url,
        bool isImage)
    {
        Url = url;
        IsImage = isImage;
    }


    public static ProductAttachments Create(
        string url,
        bool isImage)
    {
        var productAttachments = new ProductAttachments(
            url,
            isImage);

        return productAttachments;
    }


}