using System;
using System.Collections.Generic;
using System.Linq;

namespace eShopOnBlazor.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public List<CartItem> Items { get; set; } = new();
    public decimal TotalPrice => Items.Sum(i => i.Item.Price * i.Quantity);
}
