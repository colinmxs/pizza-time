namespace PizzaTime.Core.PointOfSaleMachinev2.Responses
{
    using PizzaTime.Core.CashRegisters;
    using PizzaTime.Core.Orders;
    using PizzaTime.Core.Tickets;
    using System.Collections.Generic;

    public class PlaceOrderResponse
    {
        public bool Success { get; }

        public PlaceOrderResponse(bool result)
        {
            Success = result;
        }

        public IEnumerable<Ticket> Tickets { get; internal set; }
        public ICashDrawer CashDrawer { get; internal set; }
        public Order Order { get; internal set; }
    }
}