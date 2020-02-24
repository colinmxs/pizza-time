namespace PizzaTime.Core.Customers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = new List<Customer>();
        private readonly Random _random;
        private int Next => _random.Next(_customers.Count);

        public CustomerRepository() 
        {            
            _random = new Random();
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

        public Customer GetRandom()
        {            
            return _customers[Next];
        }

        public void Remove(Customer customer)
        {
            _customers.Remove(customer);
        }
    }
}
