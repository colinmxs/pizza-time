using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class AddressResponse : ThingToSayCategory
    {
        public AddressResponse() : base(nameof(AddressResponse), AddressRequest, AddressVerification, OrderRequest, PhoneNumberRequest, HoldRequest, PhoneNumberVerification, OrderVerification)
        { }
    }
}
