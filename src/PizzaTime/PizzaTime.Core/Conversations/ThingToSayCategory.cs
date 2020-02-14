using System.Collections.Generic;

namespace PizzaTime.Core.Conversations
{
    public interface IThingToSayCategory
    {
        string Id { get; }
        string Name { get; }
        IEnumerable<IThingToSayCategory> ResponseCategories { get; set; }
    }

    public class ThingToSayCategory : IThingToSayCategory
    {
        public string Id => throw new System.NotImplementedException();

        public string Name => throw new System.NotImplementedException();

        public IEnumerable<IThingToSayCategory> ResponseCategories { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
