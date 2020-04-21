namespace PizzaTime.Core.Customers
{
    using System;
    using System.Collections.Generic;

    public interface ICustomerRepository
    {   
        void Add(Customer customer);
        Customer GetById(Guid id);
        Customer GetRandom();
        void Remove(Customer customer);
        IEnumerable<Customer> Search(Func<Customer, bool> search);
    }
}
