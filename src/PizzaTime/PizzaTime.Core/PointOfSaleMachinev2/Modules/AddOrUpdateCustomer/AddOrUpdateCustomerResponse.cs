using PizzaTime.Core.Customers;

namespace PizzaTime.Core.PointOfSaleMachinev2.Modules.AddOrUpdateCustomer
{
    public class AddOrUpdateCustomerResponse
    {
        private bool success;

        public AddOrUpdateCustomerResponse(bool success)
        {
            this.success = success;
        }

        public Customer Customer { get; internal set; }
    }
}