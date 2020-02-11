namespace PizzaTime.Core
{
    public interface ICall 
    {
        IConversation Conversation { get; set; }
    }
    public class Call : ICall
    {
        public IConversation Conversation { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}