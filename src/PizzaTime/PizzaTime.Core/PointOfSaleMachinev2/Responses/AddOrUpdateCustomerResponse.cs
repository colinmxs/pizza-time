using PizzaTime.Core.Customers;

namespace PizzaTime.Core.PointOfSaleMachinev2.Responses
{
    public class AddOrUpdateCustomerResponse //: IPointOfSaleResponse
    {
        public bool Success { get; }

        public AddOrUpdateCustomerResponse(bool success)
        {
            this.Success = success;
        }

        public Customer Customer { get; internal set; }
    }
}