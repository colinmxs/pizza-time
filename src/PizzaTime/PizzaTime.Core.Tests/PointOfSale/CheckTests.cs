namespace PizzaTime.Core.Tests.PointOfSale
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PizzaTime.Core.PointOfSale;
    using Shouldly;
    using System;

    [TestClass]
    public class CheckTests
    {
        [TestMethod]
        public void Constructor_SetsProps()
        {
            var name = "Danny McBride";
            var dateTime = DateTime.Now;
            var amount = 38.48M;
            var check = new Check(name, dateTime, amount);
            check.Name.ShouldBe(name);
            check.Date.ShouldBe(dateTime);
            check.Amount.ShouldBe(amount);
        }
    }
}