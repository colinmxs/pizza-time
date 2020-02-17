namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public class PhoneNumberVerification : ThingToSayCategory
    {
        public PhoneNumberVerification() : base(nameof(PhoneNumberVerification), GenericAffirmative, GenericAffirmative, PhoneNumberResponse)
        { }
    }
}
