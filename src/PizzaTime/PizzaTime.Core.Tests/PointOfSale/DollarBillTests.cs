namespace PizzaTime.Core.Tests.PointOfSale
{
    using FakeItEasy;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PizzaTime.Core.PointOfSale;
    using Shouldly;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class DollarBillTests
    {
        [TestMethod]
        public void Equals_Overrides()
        {
            var bill = DollarBill.One;
            var bill2 = DollarBill.One;
            (bill == bill2).ShouldBeFalse();
            (bill == bill).ShouldBeTrue();
        }
    }
}
