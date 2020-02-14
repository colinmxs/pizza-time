namespace PizzaTime.Core.Conversations
{
    public interface IThingToSay
    {
        string Text { get; set; }
        IThingToSayCategory Category { get; set; }
    }

    public class ThingToSay : IThingToSay
    {
        public string Text { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IThingToSayCategory Category { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
