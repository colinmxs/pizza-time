using PizzaTime.Core.Customers;

namespace PizzaTime.Core.PointOfSale.Responses
{
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