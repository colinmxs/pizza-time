using PizzaTime.Core.Customers;

namespace PizzaTime.Core.PointOfSale.Responses
{
    public class LookupCustomerResponse
    {
        public bool Success { get; }

        public LookupCustomerResponse(bool success)
        {
            Success = success;
        }

        public Customer Customer { get; internal set; }
        public string Remarks { get; internal set; }
    }
}