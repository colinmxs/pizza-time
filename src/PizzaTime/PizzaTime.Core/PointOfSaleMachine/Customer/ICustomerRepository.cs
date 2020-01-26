using System;

namespace PizzaTime.Core.PointOfSaleMachine.Customer
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        Customer GetByPhoneNumber(string phoneNumber);
        Customer GetById(Guid id);
        void Remove(Customer customer);
    }
}
