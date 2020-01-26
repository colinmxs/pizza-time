namespace PizzaTime.Core.PointOfSaleMachine.Requests
{
    using PizzaTime.Core.PointOfSaleMachine.Order;

    public class PlaceOrderRequest
    {
        public Order Order { get; set; }
    }
}