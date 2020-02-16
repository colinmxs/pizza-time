using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class AddressRequest : ThingToSayCategory
    {
        public AddressRequest() : base(nameof(AddressRequest), new List<IThingToSayCategory>
        {
            new AddressResponse()
        })
        { }
    }
}
