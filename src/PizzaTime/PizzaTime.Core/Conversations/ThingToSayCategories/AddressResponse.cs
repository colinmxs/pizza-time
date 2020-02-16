using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class AddressResponse : ThingToSayCategory
    {
        public AddressResponse() : base(nameof(AddressResponse), new List<IThingToSayCategory>
        {
            new AddressVerification(), new OrderRequest(), new PhoneNumberRequest(), new HoldRequest(), new PhoneNumberVerification(), new OrderVerification()
        })
        { }
    }
}
