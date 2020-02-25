using PizzaTime.Core.Food.Core;
using System.Collections.Generic;

namespace PizzaTime.Core.Food
{
    public static class Pizzas
    {
        public static readonly Pizza Pepperoni = new Pizza(new List<PizzaIngredient>()
        {
            PizzaIngredients.Pepperoni
        })
        { 
            Name = "Pepperoni"
        };

        public static readonly Pizza Hawaiian = new Pizza(new List<PizzaIngredient>()
        {
            PizzaIngredients.CanadianBacon,
            PizzaIngredients.Pineapple
        })
        {
            Name = "Hawaiian"
        };

        public static readonly Pizza Cheese = new Pizza(new List<PizzaIngredient>()
        {
        })
        {
            Name = "Cheese"
        };

        public static readonly Pizza Combination = new Pizza(new List<PizzaIngredient>()
        {
            PizzaIngredients.BellPeppers,
            PizzaIngredients.Onions,
            PizzaIngredients.Olives,
            PizzaIngredients.Mushrooms,
            PizzaIngredients.Pepperoni,
            PizzaIngredients.Sausage,
            PizzaIngredients.Ham,
            PizzaIngredients.Salami
        })
        {
            Name = "Combination"
        };

        public static readonly Pizza Meat = new Pizza(new List<PizzaIngredient>()
        {
            PizzaIngredients.Pepperoni,
            PizzaIngredients.Sausage,
            PizzaIngredients.Ham,
            PizzaIngredients.Salami,
            PizzaIngredients.Beef,
            PizzaIngredients.CanadianBacon,
            PizzaIngredients.Bacon
        })
        {
            Name = "Meat Lovers"
        };

        public static readonly Pizza Vegetarian = new Pizza(new List<PizzaIngredient>()
        {
            PizzaIngredients.ArtichokeHearts,
            PizzaIngredients.BellPeppers,
            PizzaIngredients.Mushrooms,
            PizzaIngredients.Olives,
            PizzaIngredients.Onions,
            PizzaIngredients.Tomatoes
        })
        {
            Name = "Vegetarian"
        };

        public static readonly Pizza BBQChicken = new Pizza(new List<PizzaIngredient>()
        {
            PizzaIngredients.Chicken,
            PizzaIngredients.GreenOnions
        })
        {
            Name = "BBQ Chicken",
            Sauce = PizzaSauce.BBQ            
        };

        public static readonly Pizza GarlicChicken = new Pizza(new List<PizzaIngredient>()
        {
            PizzaIngredients.Chicken,
            PizzaIngredients.GreenOnions,
            PizzaIngredients.Mushrooms
        })
        {
            Name = "Garlic Chicken",
            Sauce = PizzaSauce.White
        };

        public static readonly Pizza Pesto = new Pizza(new List<PizzaIngredient>()
        {
            PizzaIngredients.Tomatoes,
            PizzaIngredients.Garlic
        })
        {
            Name = "Pesto Pizza",
            Sauce = PizzaSauce.Pesto
        };
    }
}
