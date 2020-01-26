namespace PizzaTime.Core.PointOfSaleMachine.Responses
{
    using PizzaTime.Core.PointOfSaleMachine.Customer;

    public class AddOrUpdateCustomerResponse
    {
        public bool Success { get; }

        public AddOrUpdateCustomerResponse(bool success)
        {
            this.Success = success;
        }

        public Customer Customer { get; internal set; }
    }
}