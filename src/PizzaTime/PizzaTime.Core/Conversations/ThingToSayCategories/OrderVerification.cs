using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class OrderVerification : ThingToSayCategory
    {
        public OrderVerification() : base(nameof(OrderVerification), new List<IThingToSayCategory>()
        {

        }) { }
    }
}
