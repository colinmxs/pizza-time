using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaTime.Core.Conversations
{
    public interface IConversation 
    {
        event Action<IThingToSay> SayThing;
        IEnumerable<IConversationParticipant> Participants { get; }
        Task Say(IThingToSay thingToSay, IConversationParticipant participant);
        void AddToConversation(IConversationParticipant participant);
    }
    public class Conversation : IConversation
    {
        private List<IConversationParticipant> _participants = new List<IConversationParticipant>();
        public IEnumerable<IConversationParticipant> Participants => _participants;

        public Conversation(List<IConversationParticipant> participants)
        {
            participants.ForEach(p => AddToConversation(p));
        }

        public event Action<IThingToSay> SayThing;

        public void AddToConversation(IConversationParticipant participant)
        {
            if (participant == null) throw new ArgumentNullException(nameof(participant));

            _participants.Add(participant);
            SayThing += participant.HearThing;
        }

        public async Task Say(IThingToSay thingToSay, IConversationParticipant participant)
        {
            SayThing -= participant.HearThing;
            SayThing(thingToSay);
            SayThing += participant.HearThing;
        }
    }
}