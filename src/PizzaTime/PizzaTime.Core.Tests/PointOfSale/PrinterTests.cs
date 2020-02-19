namespace PizzaTime.Core.Tests.PointOfSale
{
    using FakeItEasy;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PizzaTime.Core.Orders;
    using PizzaTime.Core.PointOfSale;
    using PizzaTime.Core.Printers;
    using Shouldly;
    using System;
    using System.Collections.Generic;
    using static PizzaTime.Core.Orders.Order;

    [TestClass]
    public class PrinterTests
    {
        [TestMethod]
        public void PrintsKitchenTicket()
        {
            var printer = new Printer();
            var order = new Order(OrderType.Delivery)
            {
                OrderItems = new List<IOrderItem>
                {
                    A.Fake<IOrderItem>()
                }
            };

            var ticket = printer.PrintTickets(order);
            ticket.Length.ShouldBe(1);
        }
    }
}
