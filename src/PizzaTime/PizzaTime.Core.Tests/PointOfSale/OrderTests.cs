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
    public class OrderTests
    {
        [TestMethod]
        public void Order()
        {
            var order = new Order(Core.PointOfSale.Order.OrderType.Delivery);
            order.Type.ShouldBe(Core.PointOfSale.Order.OrderType.Delivery);

            order.PaymentStatus.ShouldBe(false);
            order.Pay();
            order.PaymentStatus.ShouldBe(true);
        }
    }
}
