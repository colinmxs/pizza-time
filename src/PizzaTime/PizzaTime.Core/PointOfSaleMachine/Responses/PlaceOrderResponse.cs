namespace PizzaTime.Core.PointOfSaleMachine.Responses
{
    using PizzaTime.Core.PointOfSaleMachine.Printer;
    using PizzaTime.Core.PointOfSaleMachine.Order;
    using System.Collections.Generic;
    using PizzaTime.Core.PointOfSaleMachine.CashRegister.CashDrawer;

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