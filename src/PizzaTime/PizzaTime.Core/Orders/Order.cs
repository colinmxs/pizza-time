namespace PizzaTime.Core.Orders
{
    using PizzaTime.Core.Customers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Order
    {
        public enum OrderType
        {
            DineIn = 0,
            TakeOut = 1,
            Delivery = 2
        }

        public Order() { }

        public Order(OrderType orderType)
        {
            Type = orderType;
        }

        public int Id { get; internal set; }
        public OrderType Type { get; set; }
        public IEnumerable<IOrderItem> OrderItems { get; set; }
        public bool PaymentStatus { get; private set; } = false;
        public DateTime OrderTime { get; private set; } = DateTime.UtcNow;

        public Customer Customer { get; set; }
        public decimal Subtotal => OrderItems.Sum(orderItem => orderItem.Price);
        public decimal Tax => 0.05M * Subtotal;
        public decimal Total => Subtotal + Tax;

    }
}
