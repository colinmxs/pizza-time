namespace PizzaTime.Core.Food.Pizzas.Core
{
    public class PizzaCrust
    {
        private PizzaCrust() { }
        public PizzaCrust(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public static PizzaCrust Regular => new PizzaCrust("Regular", 5M);
        public static PizzaCrust Sour => new PizzaCrust("Sour", 7.50M);
        public static PizzaCrust WholeWheat => new PizzaCrust("WholeWheat", 7.50M);
        public decimal Cost { get; internal set; }
        public string Name { get; internal set; }
    }
}