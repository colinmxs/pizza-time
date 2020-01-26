namespace PizzaTime.Core.PointOfSale
{
    using System;

    public interface ICustomerRepository
    {
        void Add(Customer customer);
        Customer GetByPhoneNumber(string phoneNumber);
        Customer GetById(Guid id);
        void Remove(Customer customer);
    }
}
