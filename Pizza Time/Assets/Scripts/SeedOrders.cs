using PizzaTime.Core.Food.Pizzas.Core;
using PizzaTime.Core.Orders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

internal class SeedOrders
{
    public SeedOrders()
    {
    }

    public int AmountToSeed { get; set; }

    public async Task<IEnumerable<Order>> Seed()
    {
        var orders = new List<Order>();

        for (int i = 0; i < AmountToSeed; i+=2)
        {
            orders.Add(SeedDelivery());
            orders.Add(SeedPickup());
        }
        return orders;
    }

    private Order SeedDelivery()
    {
        return new Order(Order.OrderType.Delivery)
        {
            OrderItems = new List<IOrderItem> 
            {
                new PizzaOrderItem(new Pizza(new List<PizzaIngredient>
                {
                    new PizzaIngredient
                    {
                        Name = "Pepperoni",

                    }
                }))
            }
        };
    }

    private Order SeedPickup() 
    {
        return new Order(Order.OrderType.TakeOut)
        {

        };
    }
}