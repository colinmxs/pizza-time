using PizzaTime.Core.Customers;
using PizzaTime.Core.Orders;
using System.Collections.Generic;

public class Seeder
{
    static Seeder()
    {
        CustomerRepository = new CustomerRepository(Customers);
    }
    private static readonly SeedCustomers seedCustomers = new SeedCustomers 
    {
        AmountToSeed = 100
    };

    private static readonly SeedOrders seedOrders = new SeedOrders 
    {
        AmountToSeed = 100
    };

    public static IEnumerable<Customer> Customers => seedCustomers.Seed().Result;
    public static IEnumerable<Order> Orders => seedOrders.Seed().Result;
    public static ICustomerRepository CustomerRepository { get; private set; }
}
