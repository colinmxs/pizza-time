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
        public string Name { get; }
        public IEnumerable<IThingToSayCategory> ResponseCategories { get; }

        public ThingToSayCategory(string name, IEnumerable<IThingToSayCategory> responseCategories)
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
