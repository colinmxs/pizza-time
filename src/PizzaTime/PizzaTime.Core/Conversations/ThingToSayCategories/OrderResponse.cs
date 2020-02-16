using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class OrderResponse : ThingToSayCategory
    {
        public OrderResponse() : base(nameof(OrderResponse), new List<IThingToSayCategory>
        {

        })
        { }
    }
}
