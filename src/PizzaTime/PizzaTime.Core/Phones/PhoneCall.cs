using PizzaTime.Core.Conversations;
using PizzaTime.Core.Customers;
using PizzaTime.Core.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaTime.Core.Phones
{
    public interface IPhoneCall 
    {
        IConversation Conversation { get; }
        IConversationParticipant Caller { get; }
        IConversationParticipant Player { get; }
    }
    public class PhoneCall : IPhoneCall
    {
        public IConversationParticipant Caller { get; }
        public IConversationParticipant Player { get; }
        public PhoneCall(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            var phoneGreetingResponse = new ThingToSay($"{order.Type}, please.", ThingToSayCategory.PhoneGreetingResponse);
            Caller = new ConversationParticipant(new List<IThingToSay>()
            {
                phoneGreetingResponse,
                new ThingToSay("No", ThingToSayCategory.GenericNegative),
                new ThingToSay("Yes", ThingToSayCategory.GenericAffirmative),
                new ThingToSay(order.Customer.PhoneNumber, ThingToSayCategory.PhoneNumberResponse),
                new ThingToSay(order.Customer.Address, ThingToSayCategory.AddressResponse),
                GetOrderThingToSay(order)
            }, null);
            var phoneGreeting = new ThingToSay("Pickup? Or delivery?", ThingToSayCategory.PhoneGreeting);
            Player = new ConversationParticipant(new List<IThingToSay>()
            {
                phoneGreeting,
                new ThingToSay("Hold please...", ThingToSayCategory.HoldRequest),
                new ThingToSay("What's your phone number?", ThingToSayCategory.PhoneNumberRequest),
                new ThingToSay("What's your address?", ThingToSayCategory.AddressRequest),
                new ThingToSay("What's your order?", ThingToSayCategory.OrderRequest),
                new ThingToSay("I've got 2099293394 for your phone number. Is that correct?", ThingToSayCategory.PhoneNumberVerification),
                new ThingToSay("I've got 212 Cherry Lane down as your address? Correct?", ThingToSayCategory.AddressVerification),
                new ThingToSay("I've got 2 large pepperoni pizzas. Anything else?", ThingToSayCategory.OrderVerification)
            }, phoneGreeting);

            Conversation = new Conversation(new List<IConversationParticipant> { Caller, Player });
        }

        private IThingToSay GetOrderThingToSay(Order order)
        {
            var stringBuilder = new StringBuilder();

            foreach (var item in order.OrderItems)
            {
                stringBuilder.AppendLine($"A {item.Name} ");
                if(item.SpecialInstructions.Any())
                {
                    stringBuilder.AppendLine("with ");

                    foreach (var instruction in item.SpecialInstructions)
                    {
                        stringBuilder.Append($"{instruction}, ");
                    }
                    stringBuilder.Append(".");
                }
            }
            return new ThingToSay(stringBuilder.ToString(), ThingToSayCategory.OrderResponse);
        }

        public IConversation Conversation { get; }
    }
}