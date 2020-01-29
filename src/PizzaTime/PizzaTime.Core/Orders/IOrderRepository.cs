using System.Collections.Generic;

namespace PizzaTime.Core.Orders
{
    public interface IOrderRepository
    {
        bool Add(Order order);
        IEnumerable<Order> GetOrders(int page);
    }
}