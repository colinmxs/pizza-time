namespace PizzaTime.Core.PointOfSale
{
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

        public Order(OrderType orderType)
        {
            Type = orderType;
        }

        public OrderType Type { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public Customer Customer { get; set; }
        public decimal Subtotal => OrderItems.Sum(orderItem => orderItem.Price);
        public decimal Tax => 0.05M * Subtotal;
        public decimal Total => Subtotal + Tax;
    }
}
