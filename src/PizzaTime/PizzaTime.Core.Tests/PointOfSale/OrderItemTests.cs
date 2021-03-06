﻿namespace PizzaTime.Core.Tests.PointOfSale
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PizzaTime.Core.Food.Pizzas.Core;
    using PizzaTime.Core.PointOfSale;
    using Shouldly;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class OrderItemTests
    {
        [TestMethod]
        public void Pizza()
        {
            var ingredients = new List<PizzaIngredient>()
            {
                new PizzaIngredient
                {
                    Name = "Pepperoni",
                    CostPerServing = 2M
                },
                new PizzaIngredient
                {
                    Name = "Pineapple",
                    CostPerServing = .5M
                }
            };

            var pizza = new Pizza(ingredients);
            pizza.Name.ShouldBe("Pizza (Custom)");
            pizza.Crust.Name.ShouldBe("Regular");
            pizza.Sauce.Name.ShouldBe("Red");            
        }
    }
}
