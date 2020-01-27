using System.Collections.Generic;

namespace PizzaTime.Core.PointOfSale
{
    public interface IOrderRepository
    {
        bool Add(Order order);
        IEnumerable<Order> GetOrders(int page);
    }
}