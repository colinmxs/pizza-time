using System.Collections.Generic;

namespace PizzaTime.Core.Conversations
{
    public interface IConversationParticipant
    {
        IEnumerable<IThingToSay> ThingsToSay { get; set; }
        void SayThing(IThingToSay thingToSay);
        void HearThing(IThingToSay thingToHear);
        void JoinConversation(IConversation convo);
    }

    public class ConversationParticipant : IConversationParticipant
    {
        public IEnumerable<IThingToSay> ThingsToSay { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void HearThing(IThingToSay thingToHear)
        {
            throw new System.NotImplementedException();
        }

        public void JoinConversation(IConversation convo)
        {
            throw new System.NotImplementedException();
        }

        public void SayThing(IThingToSay thingToSay)
        {
            throw new System.NotImplementedException();
        }
    }
}
