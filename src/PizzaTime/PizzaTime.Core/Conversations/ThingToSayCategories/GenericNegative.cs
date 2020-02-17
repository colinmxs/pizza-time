using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class GenericNegative : ThingToSayCategory
    {
        public GenericNegative() : base(nameof(GenericNegative), AddressRequest, AddressVerification, HoldRequest, OrderRequest, OrderVerification, PhoneNumberRequest, PhoneNumberVerification)
        { }
    }
}
