namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class PhoneGreetingResponse : ThingToSayCategory
    {
        public PhoneGreetingResponse() : base(nameof(PhoneGreetingResponse), PhoneNumberRequest, PhoneNumberVerification, AddressRequest, AddressVerification, HoldRequest, OrderRequest, OrderVerification)
        { }
    }
}
