namespace PizzaTime.Core.Food.Pizzas.Core
{
    public class PizzaSauce
    {
        private PizzaSauce() { }
        public PizzaSauce(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public static PizzaSauce Red => new PizzaSauce("Red", 2M);
        public static PizzaSauce White => new PizzaSauce("White", 2.50M);
        public static PizzaSauce Pesto => new PizzaSauce("Pesto", 2.50M);
        public static PizzaSauce BBQ => new PizzaSauce("BBQ", 2.50M);
        public decimal Cost { get; internal set; }
        public string Name { get; internal set; }
    }
}