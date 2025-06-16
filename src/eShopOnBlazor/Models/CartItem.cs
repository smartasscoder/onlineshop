
namespace eShopOnBlazor.Models;

public class CartItem
{
    public CatalogItem Item { get; set; } = default!;
    public int Quantity { get; set; }
}
