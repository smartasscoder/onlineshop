using System.Linq;
using eShopOnBlazor.Models;

namespace eShopOnBlazor.Services;

public class CartService
{
    private readonly List<CartItem> _items = new();

    public IReadOnlyList<CartItem> Items => _items;

    public int TotalItems => _items.Sum(i => i.Quantity);

    public decimal TotalPrice => _items.Sum(i => i.Item.Price * i.Quantity);

    public void AddItem(CatalogItem item)
    {
        var existing = _items.FirstOrDefault(i => i.Item.Id == item.Id);
        if (existing != null)
        {
            existing.Quantity++;
        }
        else
        {
            _items.Add(new CartItem { Item = item, Quantity = 1 });
        }
    }

    public void RemoveItem(int itemId)
    {
        var existing = _items.FirstOrDefault(i => i.Item.Id == itemId);
        if (existing != null)
        {
            existing.Quantity--;
            if (existing.Quantity <= 0)
            {
                _items.Remove(existing);
            }
        }
    }

    public void Clear() => _items.Clear();
}
