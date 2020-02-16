using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class PhoneGreetingResponse : ThingToSayCategory
    {
        public PhoneGreetingResponse() : base(nameof(PhoneGreetingResponse), new List<IThingToSayCategory>
        {

        })
        { }
    }
}
