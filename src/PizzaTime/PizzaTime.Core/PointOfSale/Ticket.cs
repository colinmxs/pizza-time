using System.Collections.Generic;

namespace PizzaTime.Core.PointOfSale
{
    public class Ticket
    {
        public IEnumerable<IOrderItem> OrderItems { get; set; }
    }
}
