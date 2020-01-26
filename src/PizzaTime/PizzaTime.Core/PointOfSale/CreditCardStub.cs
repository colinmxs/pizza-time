namespace PizzaTime.Core.PointOfSale
{
    public class CreditCardStub
    {
        public CreditCardStub(string name, decimal amount)
        {
            Name = name;
            Amount = amount;
        }

        public string Name { get; }
        public decimal Amount { get; }
    }
}