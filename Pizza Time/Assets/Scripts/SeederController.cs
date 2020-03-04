using PizzaTime.Core.Customers;
using PizzaTime.Core.Orders;
using System.Collections.Generic;
using UnityEngine;

public class SeederController : MonoBehaviour
{
    private readonly SeedCustomers seedCustomers = new SeedCustomers 
    {
        AmountToSeed = 100
    };

    private readonly SeedOrders seedOrders = new SeedOrders 
    {
        AmountToSeed = 100
    };

    public IEnumerable<Customer> Customers => seedCustomers.Seed().Result;
    public IEnumerable<Order> Orders => seedOrders.Seed().Result;
    public ICustomerRepository CustomerRepository { get; private set; }

    private void Awake()
    {
        CustomerRepository = new CustomerRepository(Customers);
    }
}
