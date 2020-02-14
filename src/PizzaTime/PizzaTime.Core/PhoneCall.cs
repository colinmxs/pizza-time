namespace PizzaTime.Core
{
    public interface IPhoneCall 
    {
        IConversation Conversation { get; set; }
    }
    public class PhoneCall : IPhoneCall
    {
        public IConversation Conversation { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    }
}