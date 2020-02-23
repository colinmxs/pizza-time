using PizzaTime.Core.Customers;
using PizzaTime.Core.Phones;

namespace PizzaTime.Core
{
    public interface IPhoneCallService
    {
        IPhoneCall GetCall();
    }

    public class PhoneCallService : IPhoneCallService
    {
        private readonly ICustomerRepository _repo;

        public PhoneCallService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public IPhoneCall GetCall()
        {
            var customer = _repo.GetRandom();
            return new PhoneCall(customer);
        }
    }
}