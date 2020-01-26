namespace PizzaTime.Core.PointOfSaleMachine.Responses
{
    using PizzaTime.Core.PointOfSaleMachine.Customer;

    public class LookupCustomerResponse
    {
        public bool Success { get; }

        public LookupCustomerResponse(bool success)
        {
            Success = success;
        }

        public Customer Customer { get; internal set; }
    }
}