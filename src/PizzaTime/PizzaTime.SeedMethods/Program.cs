using System;
using System.Threading.Tasks;

namespace PizzaTime.SeedMethods
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await Conversation();
            var customerSeed = new SeedCustomers();
            customerSeed.AmountToSeed = 100;
            foreach (var item in await customerSeed.Seed())
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}, :: {item.Address}");
            }
        }
    }
}
