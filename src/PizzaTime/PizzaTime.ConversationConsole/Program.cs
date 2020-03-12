using CsvHelper;
using PizzaTime.Core;
using PizzaTime.Core.Conversations;
using PizzaTime.Core.Customers;
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
        static async Task Main(string[] args)
        {
            var customers = await new SeedCustomers
            {
                AmountToSeed = 100
            }
            .Seed();

            var orders = await new SeedOrders
            {
                AmountToSeed = 1000
            }
            .Seed();

            var callService = new PhoneCallService(new CustomerRepository(customers), new OrderRepository(orders));
            List<MessageBody> messages = new List<MessageBody>();

            for (int i = 0; i < 500; i++)
            {
                var conversation = callService.GetCall().Conversation;
                var participant = conversation.Participants.Single(p => ((ConversationParticipant)p).Type == ConversationParticipant.CallerType.Caller);
                foreach (var thingToSay in participant.SpeechBank)
                {
                    messages.Add(new MessageBody
                    {
                        Input = thingToSay.Text,
                        Type = thingToSay.Category.Name.ToString(),
                        Voice = "All"
                    });
                }
            }

            using (var writer = new StreamWriter("things-to-say.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(messages);
            }
        }
    }
}
