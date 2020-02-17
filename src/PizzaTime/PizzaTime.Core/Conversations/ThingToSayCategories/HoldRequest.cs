using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class HoldRequest : ThingToSayCategory
    {
        public HoldRequest() : base(nameof(HoldRequest), GenericNegative, GenericAffirmative)
        { }
    }
}
