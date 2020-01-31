namespace PizzaTime.Core.PointOfSale.Responses
{
    using PizzaTime.Core.Orders;
    using System.Collections.Generic;

    public class GetOrdersResponse
    {
        public IEnumerable<Order> Orders { get; internal set; }
    }
}