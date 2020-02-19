namespace PizzaTime.Core.Tests.PointOfSale
{
    using FakeItEasy;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PizzaTime.Core.Orders;
    using PizzaTime.Core.PointOfSale;
    using Shouldly;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static PizzaTime.Core.Orders.Order;

    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void Order()
        {
            var order = new Order(OrderType.Delivery);
            order.Type.ShouldBe(OrderType.Delivery);

            order.PaymentStatus.ShouldBe(false);
        }
    }
}
