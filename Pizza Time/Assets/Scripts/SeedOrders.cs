using PizzaTime.Core.Food;
using PizzaTime.Core.Food.Core;
using PizzaTime.Core.Orders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

internal class SeedOrders
{
    public int AmountToSeed { get; set; }
    private readonly Random _random;

    public SeedOrders()
    {
        _random = new Random();
    }

    public async Task<IEnumerable<Order>> Seed()
    {
        var orders = new List<Order>();

        for (int i = 0; i < AmountToSeed; i+=2)
        {
            orders.Add(Seed(Order.OrderType.Delivery));
            orders.Add(Seed(Order.OrderType.DineIn));
        }
        return orders;
    }

    private readonly int pizzasCount = 9;

    private Order Seed(Order.OrderType orderType)
    {
        var orderSize = _random.Next();

        var nextPizza = _random.Next(pizzasCount);
        var nextSize = _random.Next(4);
        
        var order = new Order(orderType);        


        return new Order(orderType)
        {
            OrderItems = new List<IOrderItem> 
            {                
            }
        };
    }
}