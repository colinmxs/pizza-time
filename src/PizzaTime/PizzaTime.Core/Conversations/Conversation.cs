using System.Collections.Generic;

namespace PizzaTime.Core.Conversations
{
    public interface IConversation 
    {
        IEnumerable<IConversationParticipant> Participants { get; set; }
        void SayThing(IThingToSay thingToSay);
        void AddToConversation(IConversationParticipant participant);
    }
    public class Conversation : IConversation
    {
        public IEnumerable<IConversationParticipant> Participants { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void AddToConversation(IConversationParticipant participant)
        {
            throw new System.NotImplementedException();
        }

        public void SayThing(IThingToSay thingToSay)
        {
            throw new System.NotImplementedException();
        }
    }
}