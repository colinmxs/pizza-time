using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class GenericAffirmative : ThingToSayCategory
    {
        public GenericAffirmative() : base(nameof(GenericAffirmative), AddressRequest, AddressVerification, HoldRequest, OrderRequest, OrderVerification, PhoneNumberRequest, PhoneNumberVerification)
        { }
    }
}
