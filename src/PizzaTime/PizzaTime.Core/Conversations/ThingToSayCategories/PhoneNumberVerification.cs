using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class PhoneNumberVerification : ThingToSayCategory
    {
        public PhoneNumberVerification() : base(nameof(PhoneNumberVerification), new List<IThingToSayCategory>
        {

        })
        { }
    }
}
