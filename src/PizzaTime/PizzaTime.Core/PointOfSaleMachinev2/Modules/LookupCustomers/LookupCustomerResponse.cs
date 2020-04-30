using PizzaTime.Core.Customers;
using System.Collections.Generic;

namespace PizzaTime.Core.PointOfSaleMachinev2.Modules.LookupCustomers
{
    public class LookupCustomerResponse
    {
        public bool Success { get; }

        public LookupCustomerResponse(bool success)
        {
            Success = success;
        }

        public IEnumerable<(Customer, string)> Customers { get; internal set; }
    }
}
