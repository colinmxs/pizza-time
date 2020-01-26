namespace PizzaTime.Core.Tests.PointOfSale
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PizzaTime.Core.PointOfSale;
    using Shouldly;
    using System;

    [TestClass]
    public class CreditCardStubTests
    {
        [TestMethod]
        public void Constructor_SetsProps()
        {
            var name = "Colin Smith";
            var amount = 192M;
            var stub = new CreditCardStub(name, amount);
            stub.Name.ShouldBe(name);
            stub.Amount.ShouldBe(amount);
        }
    }
}
