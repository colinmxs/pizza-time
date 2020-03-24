using PizzaTime.Core.Food;
using PizzaTime.Core.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaTime.ConversationConsole
{
    public static class CommonOrderRepository
    {
        public static List<Order> CommonOrders 
        {
            get 
            {
                return new List<Order>
                {
                    new Order()
                    {
                        OrderItems = new List<PizzaOrderItem>
                        {
                            new PizzaOrderItem(Pizzas.Pepperoni),
                            new PizzaOrderItem(Pizzas.Pepperoni)
                        }
                    }
                };
            }
        }
    }
}
