using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class AddressVerification : ThingToSayCategory
    {
        public AddressVerification() : base(nameof(AddressVerification), GenericAffirmative, GenericNegative, AddressResponse)
        { }
    }
}
