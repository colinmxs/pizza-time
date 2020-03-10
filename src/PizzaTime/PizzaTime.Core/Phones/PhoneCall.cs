using PizzaTime.Core.Conversations;
using PizzaTime.Core.Customers;
using PizzaTime.Core.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static PizzaTime.Core.Conversations.ConversationParticipant;
using static PizzaTime.Core.Conversations.ConversationParticipantFactory;

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
            
            var conversationParticipantFactory = new ConversationParticipantFactory 
            {
                Order = order
            };
            Caller = conversationParticipantFactory.Build(CallerType.Caller);
            Player = conversationParticipantFactory.Build(CallerType.Player);

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