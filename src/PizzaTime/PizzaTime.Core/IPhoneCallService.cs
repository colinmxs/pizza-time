using PizzaTime.Core.Customers;
using PizzaTime.Core.Orders;
using PizzaTime.Core.Phones;

namespace PizzaTime.Core
{
    public interface IPhoneCallService
    {
        IPhoneCall GetCall();
    }

    public class PhoneCallService : IPhoneCallService
    {
        private readonly ICustomerRepository _customers;
        private readonly IOrderRepository _orders;

        public PhoneCallService(ICustomerRepository customers, IOrderRepository orders)
        {
            _customers = customers;
            _orders = orders;
        }

        public IPhoneCall GetCall()
        {
            var customer = _customers.GetRandom();
            var order = _orders.GetRandom();
            order.Customer = customer;
            return new PhoneCall(order);
        }
    }
}