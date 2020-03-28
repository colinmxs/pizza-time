using CsvHelper;
using PizzaTime.Core;
using PizzaTime.Core.Conversations;
using PizzaTime.Core.Customers;
using PizzaTime.Core.Levels;
using PizzaTime.Core.Orders;
using PizzaTime.VoiceFileGenerator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTime.ConversationConsole
{
    class Program
    {
        private static Random _random = new Random();
        static async Task Main(string[] args)
        {
            var customers = await new SeedCustomers
            {
                AmountToSeed = 10000
            }
            .Seed();

            var orders = await new SeedOrders
            {
                AmountToSeed = 100
            }
            .Seed();

            var callService = new PhoneCallService(new CustomerRepository(customers), new OrderRepository(orders));
            List<LevelOrder> messages = new List<LevelOrder>();

            //for (int i = 0; i < 500; i++)
            //{
            //    var order = orders.ToList()[_random.Next(orders.ToList().Count)];
            //    var customer = customers.ToList()[_random.Next(customers.ToList().Count)];
            //    order.Customer = customer;
            //    var participant = new ConversationParticipantFactory
            //    {
            //        Order = order
            //    }.Build(ConversationParticipant.CallerType.Caller);
                
            //    foreach (var thingToSay in participant.SpeechBank)
            //    {
            //        messages.Add(new LevelOrder(order, customer, participant));
            //        messages.Add(new MessageBody
            //        {
            //            Input = thingToSay.Text,
            //            Type = thingToSay.Category.Name.ToString(),
            //            Voice = "All"
            //        });
            //    }
            //}

            using (var writer = new StreamWriter("customers.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(customers);
            }            
        }
    }
}
