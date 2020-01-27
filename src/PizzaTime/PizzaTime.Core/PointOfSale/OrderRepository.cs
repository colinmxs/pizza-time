using System.Collections.Generic;
using System.Linq;

namespace PizzaTime.Core.PointOfSale
{
    public class OrderRepository : IOrderRepository
    {
        List<Order> _orders = new List<Order>();
        private int pageSize = 10;
        
        public bool Add(Order order)
        {
            var id = _orders.Count;
            order.Id = id;
            _orders.Add(order);
            return true;
        }

        public IEnumerable<Order> GetOrders(int page)
        {
            var desc = _orders.OrderByDescending(order => order.Id);
            return desc.Skip(pageSize * page).Take(pageSize);
        }
    }
}
