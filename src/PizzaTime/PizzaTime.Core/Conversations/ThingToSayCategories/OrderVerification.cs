namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class OrderVerification : ThingToSayCategory
    {
        public OrderVerification() : base(nameof(OrderVerification), GenericAffirmative, GenericNegative, OrderResponse) { }
    }
}
