using PizzaTime.Core.Food.Pizzas.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaTime.Core.Orders
{
    public class PizzaOrderItem : IOrderItem
    {
        private readonly Pizza pizza;
        public PizzaOrderItem(Pizza pizza)
        {
            if (pizza == null) throw new ArgumentNullException(nameof(pizza));
            this.pizza = pizza;
        }
        public string Name => pizza.Name;
        public decimal Price => pizza.Price;
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>()
                {
                    $"Size: {pizza.Size.Name}",
                    pizza.Crust.Name,
                    pizza.Sauce.Name
                };

                instructions.Concat(pizza.Ingredients.Select(i => $"+ {i.Name}"));
                return instructions;
            }
        }
    }
}
