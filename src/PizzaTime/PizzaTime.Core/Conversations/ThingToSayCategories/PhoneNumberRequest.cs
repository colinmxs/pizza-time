using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class PhoneNumberRequest : ThingToSayCategory
    {
        public PhoneNumberRequest() : base(nameof(PhoneNumberRequest), PhoneNumberResponse)
        { }
    }
}
