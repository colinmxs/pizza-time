using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class OrderResponse : ThingToSayCategory
    {
        public OrderResponse() : base(nameof(OrderResponse), AddressRequest, AddressVerification, HoldRequest, OrderRequest, OrderVerification, PhoneNumberRequest, PhoneNumberVerification)
        { }
    }
}
