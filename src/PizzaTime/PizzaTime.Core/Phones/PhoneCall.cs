using PizzaTime.Core.Conversations;
using PizzaTime.Core.Customers;
using System;
using System.Collections.Generic;

namespace PizzaTime.Core.Phones
{
    public interface IPhoneCall 
    {
        IConversation Conversation { get; }
    }
    public class PhoneCall : IPhoneCall
    {
        private readonly Customer _customer;
        public IConversationParticipant Caller { get; }
        public IConversationParticipant Player { get; }
        public PhoneCall(Customer customer)
        {
            if (_customer == null) throw new ArgumentNullException(nameof(customer));

            _customer = customer;
            Caller = new ConversationParticipant(new List<IThingToSay>()
            {
                new ThingToSay("Delivery, please.", ThingToSayCategory.PhoneGreetingResponse),
                new ThingToSay("Pickup, please.", ThingToSayCategory.PhoneGreetingResponse),
                new ThingToSay("No", ThingToSayCategory.GenericNegative),
                new ThingToSay("Yes", ThingToSayCategory.GenericAffirmative),
                new ThingToSay(_customer.PhoneNumber, ThingToSayCategory.PhoneNumberResponse),
                new ThingToSay(_customer.Address, ThingToSayCategory.AddressResponse),
                new ThingToSay("I'd like to order two large pepperoni pizzas", ThingToSayCategory.OrderResponse)
            });
            Player = new ConversationParticipant(new List<IThingToSay>()
            {
                new ThingToSay("Pickup? Or delivery?", ThingToSayCategory.PhoneGreeting),
                new ThingToSay("Hold please...", ThingToSayCategory.HoldRequest),
                new ThingToSay("What's your phone number?", ThingToSayCategory.PhoneNumberRequest),
                new ThingToSay("What's your address?", ThingToSayCategory.AddressRequest),
                new ThingToSay("What's your order?", ThingToSayCategory.OrderRequest),
                new ThingToSay("I've got 2099293394 for your phone number. Is that correct?", ThingToSayCategory.PhoneNumberVerification),
                new ThingToSay("I've got 212 Cherry Lane down as your address? Correct?", ThingToSayCategory.AddressVerification),
                new ThingToSay("I've got 2 large pepperoni pizzas. Anything else?", ThingToSayCategory.OrderVerification)
            });

            Conversation = new Conversation(new List<IConversationParticipant> { Caller, Player });
        }

        public IConversation Conversation { get; }
    }
}