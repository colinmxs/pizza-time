using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaTime.Core.Orders
{
    public class OrderRepository : IOrderRepository
    {
        public Guid Id = Guid.NewGuid();
        public List<Order> _orders = new List<Order>();
        private int orderCounter = 0;
        private int pageSize = 100;
        
        public bool Add(Order order)
        {
            lock (_orders)
            {
                var id = orderCounter++;
                order.Id = id + 1000000;
                _orders.Add(order);
            }
            return true;
        }

        public IEnumerable<Order> GetOrders(int page)
        {
            var desc = _orders.OrderByDescending(order => order. Id);
            return desc.Skip(pageSize * page).Take(pageSize);
        }
    }
}
