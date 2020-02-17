using System;
using System.Collections.Generic;

namespace PizzaTime.Core.Conversations.ThingToSayCategories
{
    public interface IThingToSayCategory
    {
        string Name { get; }
        IEnumerable<IThingToSayCategory> ResponseCategories { get; }
    }

    public class ThingToSayCategory : IThingToSayCategory, IEquatable<ThingToSayCategory>
    {
        public static readonly IThingToSayCategory AddressRequest = new AddressRequest();
        public static readonly IThingToSayCategory AddressResponse = new AddressResponse();
        public static readonly IThingToSayCategory AddressVerification = new AddressVerification();
        public static readonly IThingToSayCategory GenericAffirmative = new GenericAffirmative();
        public static readonly IThingToSayCategory GenericNegative = new GenericNegative();
        public static readonly IThingToSayCategory HoldRequest = new HoldRequest();
        public static readonly IThingToSayCategory OrderRequest = new OrderRequest();
        public static readonly IThingToSayCategory OrderResponse = new OrderResponse();
        public static readonly IThingToSayCategory OrderVerification = new OrderVerification();
        public static readonly IThingToSayCategory PhoneGreeting = new PhoneGreeting();
        public static readonly IThingToSayCategory PhoneGreetingResponse = new PhoneGreetingResponse();
        public static readonly IThingToSayCategory PhoneNumberRequest = new PhoneNumberRequest();
        public static readonly IThingToSayCategory PhoneNumberResponse = new PhoneNumberResponse();
        public static readonly IThingToSayCategory PhoneNumberVerification = new PhoneNumberVerification();
        public string Name { get; }
        public IEnumerable<IThingToSayCategory> ResponseCategories { get; }

        protected ThingToSayCategory(string name, params IThingToSayCategory[] responseCategories)
        {
            Name = name;
            ResponseCategories = responseCategories;
        }

        public bool Equals(ThingToSayCategory other)
        {
            if (other == null) return false;
            return Name == other.Name;
        }

        public override bool Equals(object other)
        {
            // other could be a reference type, the is operator will return false if null
            if (other is ThingToSayCategory)
                return Equals((ThingToSayCategory)other);
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
