using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaTime.Core.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new List<Order>();
        private readonly Random _random;
        private int orderCounter = 0;
        private int pageSize = 100;
        private int Next => _random.Next(_orders.Count);

        public OrderRepository()
        {
            _random = new Random();
        }

        public OrderRepository(IEnumerable<Order> orders)
        {
            _orders = orders.ToList();
        }

        public bool Add(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

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

        public Order GetRandom()
        {
            return _orders[Next];
        }
    }
}
