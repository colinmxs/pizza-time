namespace PizzaTime.Core.Food.Core
{
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        public Pizza(List<PizzaIngredient> ingredients)
        {
            Name = "Pizza (Custom)";
            Crust = PizzaCrust.Regular;
            Sauce = PizzaSauce.Red;
            Ingredients = ingredients;
        }

        public string Name { get; set; }
        public PizzaCrust Crust { get; set; }
        public PizzaSauce Sauce { get; set; }
        public PizzaSize Size { get; set; }
        public IEnumerable<PizzaIngredient> Ingredients { get; set; }
        public decimal Price
        {
            get
            {
                var ingredientsCost = Ingredients.Sum(i => i.CostPerServing);
                return (Crust.Cost + Sauce.Cost + ingredientsCost) * Size.CostMultiplier;
            }
        }
    }
}
