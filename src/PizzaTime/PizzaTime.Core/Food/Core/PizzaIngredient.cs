namespace PizzaTime.Core.Food.Core
{
    public class PizzaIngredient
    {
        public PizzaIngredient(string name, decimal cost)
        {
            Name = name;
            CostPerServing = cost;
        }

        public decimal CostPerServing { get; set; }
        public string Name { get; set; }
    }
}