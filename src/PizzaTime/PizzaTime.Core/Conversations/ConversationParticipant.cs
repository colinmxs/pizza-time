using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaTime.Core.Conversations
{
    public interface IConversationParticipant
    {
        IEnumerable<IThingToSay> SpeechBank { get; }
        IEnumerable<IThingToSay> ThingsToSay { get; }        
        void HearThing(IThingToSay thingToHear);
    }

    public class ConversationParticipant : IConversationParticipant
    {
        public enum CallerType
        {
            Caller,
            Player
        }

        private readonly IEnumerable<IThingToSay> _speechBank;
        public IEnumerable<IThingToSay> SpeechBank { get { return _speechBank; } }
        public IEnumerable<IThingToSay> ThingsToSay { get; private set; }
        public CallerType Type { get; }
        public ConversationParticipant(CallerType callerType, IEnumerable<IThingToSay> thingsToSay, IThingToSay firstThingToSay)
        {
            ThingsToSay = new List<IThingToSay> { firstThingToSay };
            _speechBank = thingsToSay;
            Type = callerType;
        }

        public void HearThing(IThingToSay thingToHear)
        {
            if (thingToHear == null) throw new ArgumentNullException(nameof(thingToHear));
            var responseCategories = thingToHear.Category.ResponseCategories;
            ThingsToSay = _speechBank.Where(tts => responseCategories.Contains(tts.Category.Name));
        }
    }
}
