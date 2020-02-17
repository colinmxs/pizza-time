using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class PhoneNumberResponse : ThingToSayCategory
    {
        public PhoneNumberResponse() : base(nameof(PhoneNumberResponse), AddressRequest, AddressVerification, HoldRequest, OrderRequest, OrderVerification, PhoneNumberRequest, PhoneNumberVerification)
        { }
    }
}
