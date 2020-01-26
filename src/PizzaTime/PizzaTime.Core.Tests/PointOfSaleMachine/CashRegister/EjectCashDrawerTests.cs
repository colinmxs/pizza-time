namespace PizzaTime.Core.Tests.PointOfSaleMachine.CashRegister
{
    using FakeItEasy;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PizzaTime.Core.PointOfSaleMachine;
    using PizzaTime.Core.PointOfSaleMachine.CashRegister;
    using PizzaTime.Core.PointOfSaleMachine.Customer;
    using PizzaTime.Core.PointOfSaleMachine.Order;
    using PizzaTime.Core.PointOfSaleMachine.Printer;
    using PizzaTime.Core.PointOfSaleMachine.Requests;
    using Shouldly;
    using System;

    [TestClass]
    public class EjectCashDrawerTests
    {
        ICashRegister cashRegister;

        [TestInitialize]
        public void Initialize()
        {
            cashRegister = new CashRegister();
        }

        [TestMethod]
        public void EjectCashDrawer_ReturnsCashDrawer()
        {
            var cashDrawer = cashRegister.EjectCashDrawer();
            cashDrawer.ShouldNotBeNull();
        }

        [TestMethod]
        public void EjectCashDrawer_SetsIsOpenToTrue()
        {
            var cashDrawer = cashRegister.EjectCashDrawer();
            cashRegister.IsOpen.ShouldBeTrue();
        }
    }
}
