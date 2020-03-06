using PizzaTime.Core.Conversations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTime.ConversationConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var greeting = new ThingToSay("Pickup? Or delivery?", ThingToSayCategory.PhoneGreeting);
            //var voiceEngine = new VoiceEngine.App()
            var participant1 = new ConversationParticipant(new List<IThingToSay>()
            {
                greeting,
                new ThingToSay("Hold please...", ThingToSayCategory.HoldRequest),
                new ThingToSay("What's your phone number?", ThingToSayCategory.PhoneNumberRequest),
                new ThingToSay("What's your address?", ThingToSayCategory.AddressRequest),
                new ThingToSay("What's your order?", ThingToSayCategory.OrderRequest),
                new ThingToSay("I've got 2099293394 for your phone number. Is that correct?", ThingToSayCategory.PhoneNumberVerification),
                new ThingToSay("I've got 212 Cherry Lane down as your address? Correct?", ThingToSayCategory.AddressVerification),
                new ThingToSay("I've got 2 large pepperoni pizzas. Anything else?", ThingToSayCategory.OrderVerification)
            }, null);
            var participant2 = new ConversationParticipant(new List<IThingToSay>() 
            { 
                new ThingToSay("Delivery, please.", ThingToSayCategory.PhoneGreetingResponse),
                new ThingToSay("Pickup, please.", ThingToSayCategory.PhoneGreetingResponse),
                new ThingToSay("No", ThingToSayCategory.GenericNegative),
                new ThingToSay("Yes", ThingToSayCategory.GenericAffirmative),
                new ThingToSay("2099293394", ThingToSayCategory.PhoneNumberResponse),
                new ThingToSay("212 Cherry Lane", ThingToSayCategory.AddressResponse),
                new ThingToSay("I'd like to order two large pepperoni pizzas", ThingToSayCategory.OrderResponse)
            }, null);
            var conversation = new Conversation(new List<IConversationParticipant>() 
            {
                participant1, participant2
            });
            
            //var tts = participant1.ThingsToSay.Single(t => t.Category == ThingToSayCategory.PhoneGreeting);
            conversation.SayThing += t => Console.WriteLine(t.Text);
            //conversation.SayThing += t => 
            await conversation.Say(greeting, participant1);
            while (true)
            {
                var ftts = participant2.ThingsToSay.First();
                await conversation.Say(ftts, participant2);
                Console.WriteLine("...");
                Console.WriteLine("Speech Options:");
                var i = 0;
                foreach (var item in participant1.ThingsToSay)
                {
                    Console.WriteLine($"Choice {i}::{item.Category.Name}");
                    i++;
                }
                int @int = Convert.ToInt32(Console.ReadLine());
                ftts = participant1.ThingsToSay.Skip(@int).First();
                await conversation.Say(ftts, participant1);
            }
        }
    }
}
