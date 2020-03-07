using PizzaTime.Core.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static PizzaTime.Core.Conversations.ConversationParticipant;

namespace PizzaTime.Core.Conversations
{
    public class ConversationParticipantFactory
    {
        public Order Order { get; set; }
        
        public IConversationParticipant Build(CallerType callerType)
        {
            IConversationParticipant conversationParticipant = null;
            switch (callerType)
            {
                case CallerType.Caller:
                    var phoneGreetingResponse = new ThingToSay($"{Order.Type}, please.", ThingToSayCategory.PhoneGreetingResponse);
                    conversationParticipant = new ConversationParticipant(callerType, new List<IThingToSay>()
                    {
                        phoneGreetingResponse,
                        new ThingToSay($"{Order.Customer.FirstName} {Order.Customer.LastName}", ThingToSayCategory.NameResponse),
                        new ThingToSay("No", ThingToSayCategory.GenericNegative),
                        new ThingToSay("Yes", ThingToSayCategory.GenericAffirmative),
                        new ThingToSay(Order.Customer.PhoneNumber, ThingToSayCategory.PhoneNumberResponse),
                        new ThingToSay(Order.Customer.Address, ThingToSayCategory.AddressResponse),
                        GetOrderThingToSay(Order),
                        new ThingToSay("Bye!", ThingToSayCategory.PhoneFarewellResponse)
                    }, null);
                    break;
                case CallerType.Player:
                    var phoneGreeting = new ThingToSay("Pickup? Or delivery?", ThingToSayCategory.PhoneGreeting);
                    var phoneFarewell = new ThingToSay(Order.Type == Order.OrderType.Delivery ? "Your delivery should arrive within 30 minutes. Thank you!" : "Your pickup order will be ready in 20 minutes. Thank you!", ThingToSayCategory.PhoneFarewell);
                    conversationParticipant = new ConversationParticipant(callerType, new List<IThingToSay>()
                    {
                        phoneGreeting,
                        new ThingToSay("What's your name?", ThingToSayCategory.NameRequest),
                        new ThingToSay("Hold please...", ThingToSayCategory.HoldRequest),
                        new ThingToSay("What's your phone number?", ThingToSayCategory.PhoneNumberRequest),
                        new ThingToSay("What's your address?", ThingToSayCategory.AddressRequest),
                        new ThingToSay("What's your order?", ThingToSayCategory.OrderRequest),
                        phoneFarewell
                    }, phoneGreeting);
                    break;
                default:
                    break;
            }

            return conversationParticipant;
        }

        private IThingToSay GetOrderThingToSay(Order order)
        {
            var stringBuilder = new StringBuilder();

            foreach (var item in order.OrderItems)
            {
                stringBuilder.Append($"A {item.Name} ");
                if (item.SpecialInstructions.Any())
                {
                    stringBuilder.Append("with ");

                    foreach (var instruction in item.SpecialInstructions)
                    {
                        stringBuilder.Append($"{instruction}, ");
                    }
                    stringBuilder.Append(".");
                }
            }
            return new ThingToSay(stringBuilder.ToString(), ThingToSayCategory.OrderResponse);
        }
    }
}
