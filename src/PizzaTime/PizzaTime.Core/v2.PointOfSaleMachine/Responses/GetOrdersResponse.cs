namespace PizzaTime.Core.v2.PointOfSaleMachine.Responses
{
    using PizzaTime.Core.Orders;
    using System.Collections.Generic;

    public class GetOrdersResponse
    {
        public IEnumerable<Order> Orders { get; internal set; }
    }
}