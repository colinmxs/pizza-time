using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class AddressVerification : ThingToSayCategory
    {
        public AddressVerification() : base(nameof(AddressVerification), new List<IThingToSayCategory>
        {
            new GenericAffirmative(), new GenericNegative(), new AddressResponse()
        })
        { }
    }
}
