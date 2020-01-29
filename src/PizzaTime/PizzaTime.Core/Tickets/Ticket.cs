using PizzaTime.Core.Orders;
using System.Collections.Generic;

namespace PizzaTime.Core.Tickets
{
    public class Ticket
    {
        public IEnumerable<IOrderItem> OrderItems { get; set; }
    }
}
