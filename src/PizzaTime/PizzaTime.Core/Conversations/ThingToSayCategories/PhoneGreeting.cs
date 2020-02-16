using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class PhoneGreeting : ThingToSayCategory
    {
        public PhoneGreeting() : base(nameof(PhoneGreeting), new List<IThingToSayCategory>
        {

        }) { }
    }
}
