namespace PizzaTime.Core.PointOfSaleMachine.CustomerRepository
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        Customer GetByPhoneNumber(string phoneNumber);
    }
}
