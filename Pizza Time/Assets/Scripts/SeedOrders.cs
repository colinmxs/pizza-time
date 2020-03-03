using PizzaTime.Core.Food;
using PizzaTime.Core.Food.Core;
using PizzaTime.Core.Orders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

internal class SeedOrders
{
    enum OrderTypes 
    {
        
        
        
    }
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
            orders.Add(Seed(Order.OrderType.TakeOut));
        }
        return orders;
    }

    private readonly int pizzasCount = 9;

    private Order Seed(Order.OrderType orderType)
    {
        var orderSize = _random.Next(5);
        var order = new Order(orderType);

        var nextPizza = _random.Next(pizzasCount);
        var nextSize = _random.Next(4);


        var orderItems = new List<IOrderItem>();

        for (int i = 0; i < orderSize; i++)
        {
            Pizza pizza;
            switch (nextPizza) 
            {
                case 0:
                    pizza = Pizzas.BBQChicken;
                    break;
                case 1:
                    pizza = Pizzas.Cheese;
                    break;
                case 2:
                    pizza = Pizzas.Combination;
                    break;
                case 3:
                    pizza = Pizzas.GarlicChicken;
                    break;
                case 4:
                    pizza = Pizzas.Hawaiian;
                    break;
                case 5:
                    pizza = Pizzas.Meat;
                    break;
                case 6:
                    pizza = Pizzas.Pepperoni;
                    break;
                case 7:
                    pizza = Pizzas.Pesto;
                    break;
                case 8:
                    pizza = Pizzas.Vegetarian;
                    break;
                default:
                    pizza = Pizzas.Pepperoni;
                    break;
            }

            switch (nextSize)
            {
                case 0:
                    pizza.Size = PizzaSizes.Small;
                    break;
                case 1:
                    pizza.Size = PizzaSizes.Medium;
                    break;
                case 2:
                    pizza.Size = PizzaSizes.Large;
                    break;
                case 3:
                    pizza.Size = PizzaSizes.ExtraLarge;
                    break;
                default:
                    pizza.Size = PizzaSizes.Medium;
                    break;
            }

            orderItems.Add(new PizzaOrderItem(pizza));
        }
        order.OrderItems = orderItems;

        return order;
    }
}