﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaTime.Core.Conversations
{
    public interface IConversationParticipant
    {
        IEnumerable<IThingToSay> ThingsToSay { get; }        
        void HearThing(IThingToSay thingToHear);
    }

    public class ConversationParticipant : IConversationParticipant
    {
        private readonly IEnumerable<IThingToSay> _speechBank;
        public IEnumerable<IThingToSay> ThingsToSay { get; private set; }

        public ConversationParticipant(IEnumerable<IThingToSay> thingsToSay, IThingToSay firstThingToSay)
        {
            ThingsToSay = new List<IThingToSay> { firstThingToSay };
            _speechBank = thingsToSay;
        }

        public void HearThing(IThingToSay thingToHear)
        {
            if (thingToHear == null) throw new ArgumentNullException(nameof(thingToHear));
            var responseCategories = thingToHear.Category.ResponseCategories;
            ThingsToSay = _speechBank.Where(tts => responseCategories.Contains(tts.Category.Name));
        }
    }
}
