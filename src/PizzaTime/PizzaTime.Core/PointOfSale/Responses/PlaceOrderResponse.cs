namespace PizzaTime.Core.PointOfSale.Responses
{
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