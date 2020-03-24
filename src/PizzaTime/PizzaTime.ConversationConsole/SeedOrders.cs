using PizzaTime.Core.Food;
using PizzaTime.Core.Food.Core;
using PizzaTime.Core.Orders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaTime.ConversationConsole
{
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

            for (int i = 0; i < AmountToSeed; i += 2)
            {
                orders.Add(Seed(Order.OrderType.Delivery));
                orders.Add(Seed(Order.OrderType.TakeOut));
            }
            return orders;
        }

        private readonly int pizzasCount = 9;

        private Order Seed(Order.OrderType orderType)
        {
            var order = new Order(orderType);
            var orderDiscriminator = _random.Next(10);
            
            // 0 - 6 == common order
            // 7 - 10 == unique order
            if(orderDiscriminator >= 7)
            {
                return SeedUniqueOrder(order);
            }
            else
            {
                return SeedCommonOrder(order);
            }
        }

        private Order SeedCommonOrder(Order order) 
        {
            List<Order> commonOrders = CommonOrderRepository.CommonOrders;
            var index = _random.Next(commonOrders.Count);
            var commonOrder = commonOrders[index];
            order.OrderItems = commonOrder.OrderItems;
            return order;
        }

        private Order SeedUniqueOrder(Order order)
        {
            var orderSize = _random.Next(5);

            var orderItems = new List<IOrderItem>();

            for (int i = 0; i < orderSize; i++)
            {
                var nextPizza = _random.Next(pizzasCount);

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
                var nextSize = _random.Next(4);

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
}
