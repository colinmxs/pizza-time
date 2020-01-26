namespace PizzaTime.Core.PointOfSaleMachine.Requests
{
    using PizzaTime.Core.PointOfSaleMachine.Customer;

    public class AddOrUpdateCustomerRequest
    {
        public Customer Customer { get; set; }
    }
}