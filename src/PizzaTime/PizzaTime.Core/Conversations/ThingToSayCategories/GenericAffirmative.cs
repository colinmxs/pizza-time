using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class GenericAffirmative : ThingToSayCategory
    {
        public GenericAffirmative() : base(nameof(GenericAffirmative), new List<IThingToSayCategory>
        {
            new AddressRequest(), new HoldRequest(), new PhoneNumberRequest(), new OrderRequest(), new AddressVerification()
        })
        { }
    }
}
