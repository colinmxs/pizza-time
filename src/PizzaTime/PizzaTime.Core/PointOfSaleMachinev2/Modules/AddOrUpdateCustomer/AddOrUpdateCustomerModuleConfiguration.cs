using PizzaTime.Core.Customers;
using System.Collections.Generic;

namespace PizzaTime.Core.PointOfSaleMachinev2.Modules.AddOrUpdateCustomer
{
    public class AddOrUpdateCustomerModuleConfiguration
    {
        public Dictionary<string, string> Notes { get; internal set; }
        public ICustomerRepository CustomerRepo { get; internal set; }
    }
}
