using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTime.Core.Conversations
{
    public interface IConversation 
    {
        event Action<IThingToSay, IConversationParticipant> SayThing;
        IEnumerable<IConversationParticipant> Participants { get; }
        bool IsActive { get; }

        Task Say(IThingToSay thingToSay, IConversationParticipant participant);
        void AddToConversation(IConversationParticipant participant);
    }
    public class Conversation : IConversation
    {
        private List<IConversationParticipant> _participants = new List<IConversationParticipant>();
        public IEnumerable<IConversationParticipant> Participants => _participants;

        public bool IsActive => Participants.Any(p => p.ThingsToSay.Any());

        public Conversation(List<IConversationParticipant> participants)
        {
            participants.ForEach(p => AddToConversation(p));
        }

        public event Action<IThingToSay, IConversationParticipant> SayThing;

        public void AddToConversation(IConversationParticipant participant)
        {
            if (participant == null) throw new ArgumentNullException(nameof(participant));

            _participants.Add(participant);
            SayThing += (tts, cp) => participant.HearThing(tts);
        }

        public async Task Say(IThingToSay thingToSay, IConversationParticipant participant)
        {
            SayThing -= (tts, cp) => participant.HearThing(tts);
            SayThing(thingToSay, participant);
            SayThing += (tts, cp) => participant.HearThing(tts);
        }
    }
}