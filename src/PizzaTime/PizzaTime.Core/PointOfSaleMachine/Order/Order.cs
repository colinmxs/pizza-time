namespace PizzaTime.Core.PointOfSaleMachine.Order
{
    using System.Collections.Generic;
    using System.Linq;
    using PizzaTime.Core.PointOfSaleMachine.Customer;

    public class Order
    {
        public Order(OrderType orderType)
        {
            OrderType = orderType;
        }

        public OrderType OrderType { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public Customer Customer { get; set; }
        public decimal Subtotal => OrderItems.Sum(orderItem => orderItem.Price);
        public decimal Tax => 0.05M * Subtotal;
        public decimal Total => Subtotal + Tax;
    }
}
