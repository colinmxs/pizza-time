namespace PizzaTime.Core.Customers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> _customers;

        public CustomerRepository() 
        {
            _customers = new List<Customer>();
        }

        public CustomerRepository(IEnumerable<Customer> customers)
        {
            _customers = customers.ToList();
        }

        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public Customer GetById(Guid id)
        {
            return _customers.SingleOrDefault(customer => customer.Id == id);
        }

        public Customer GetByPhoneNumber(string phoneNumber)
        {
            return _customers.SingleOrDefault(customer => customer.PhoneNumber == phoneNumber);
        }

        public void Remove(Customer customer)
        {
            _customers.Remove(customer);
        }
    }
}
