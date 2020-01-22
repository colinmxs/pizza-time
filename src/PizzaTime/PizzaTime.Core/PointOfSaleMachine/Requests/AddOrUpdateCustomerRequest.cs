namespace PizzaTime.Core.PointOfSaleMachine.Requests
{
    using PizzaTime.Core.PointOfSaleMachine;

    public class AddOrUpdateCustomerRequest
    {
        public string LookupPhoneNumber { get; set; }
        public Customer Customer { get; set; }
    }
}