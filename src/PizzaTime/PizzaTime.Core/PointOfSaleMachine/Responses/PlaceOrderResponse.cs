namespace PizzaTime.Core.PointOfSaleMachine.Responses
{
    public class PlaceOrderResponse
    {
        private bool result;

        public PlaceOrderResponse(bool result)
        {
            this.result = result;
        }

        public Ticket Ticket { get; set; }
        internal Order Order { get; set; }
    }
}