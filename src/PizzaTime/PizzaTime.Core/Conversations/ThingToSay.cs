using PizzaTime.Core.Conversations.ThingToSayCategories;

namespace PizzaTime.Core.Conversations
{
    public interface IThingToSay
    {
        string Text { get; }
        IThingToSayCategory Category { get; }
    }

    public class ThingToSay : IThingToSay
    {
        public IThingToSayCategory Category { get; private set; }
        public string Text { get; private set; }
        
        public ThingToSay(string text, IThingToSayCategory category)
        {
            Text = text;
            Category = category;
        }
    }
}
