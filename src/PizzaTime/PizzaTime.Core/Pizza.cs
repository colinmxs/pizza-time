using PizzaTime.Core.PointOfSale;
using System.Collections.Generic;
using System.Linq;

namespace PizzaTime.Core
{
    public class Pizza : IOrderItem
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
                var ingredientsCost = Ingredients.Sum(i => i.Cost);
                return (Crust.Cost + Sauce.Cost + ingredientsCost) * Size.CostMultiplier;
            } 
        }

        public IEnumerable<string> SpecialInstructions 
        {
            get
            {
                var instructions = new List<string>()
                {
                    $"Size: {Size.Name}",
                    Crust.Name,
                    Sauce.Name                    
                };

                instructions.Concat(Ingredients.Select(i => i.Name));
                return instructions;
            }
        }
    }
}
