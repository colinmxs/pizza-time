using PizzaTime.Core.Customers;

namespace PizzaTime.Core.PointOfSaleMachinev2.Modules.AddOrUpdateCustomer
{    
    public class AddOrUpdateCustomerRequest
    {
        public Customer Customer { get; set; }
        public string Remarks { get; set; }
        public bool AddOrder { get; set; } = false;
    }
}
