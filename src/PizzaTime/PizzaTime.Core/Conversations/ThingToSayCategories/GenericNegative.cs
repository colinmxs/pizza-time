using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class GenericNegative : ThingToSayCategory
    {
        public GenericNegative() : base(nameof(GenericNegative), new List<IThingToSayCategory>
        {

        })
        { }
    }
}
