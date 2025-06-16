using System;
using System.Collections.Generic;
using System.Linq;
using eShopOnBlazor.Models;


namespace eShopOnBlazor.Services;

public class OrderService
{
    private readonly List<Order> _orders = new();
    private int _nextId = 1;

    public IReadOnlyList<Order> Orders => _orders;

    public void AddOrder(IEnumerable<CartItem> items)
    {
        var order = new Order
        {
            Id = _nextId++,
            Created = DateTime.Now,
            Items = items.Select(i => new CartItem { Item = i.Item, Quantity = i.Quantity }).ToList()
        };
        _orders.Add(order);
    }
}
