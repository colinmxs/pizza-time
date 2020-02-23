namespace PizzaTime.Core.Customers
{
    using System;

    public interface ICustomerRepository
    {   
        void Add(Customer customer);
        Customer GetByPhoneNumber(string phoneNumber);
        Customer GetById(Guid id);
        Customer GetRandom();
        void Remove(Customer customer);
    }
}
