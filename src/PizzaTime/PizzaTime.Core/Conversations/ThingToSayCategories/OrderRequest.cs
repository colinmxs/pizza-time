using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class OrderRequest : ThingToSayCategory
    {
        public OrderRequest() : base(nameof(OrderRequest), new List<IThingToSayCategory>
        {

        })
        { }
    }
}
