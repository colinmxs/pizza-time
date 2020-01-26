namespace PizzaTime.Core.Tests.PointOfSaleMachine.CashRegister
{
    using FakeItEasy;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PizzaTime.Core.PointOfSaleMachine;
    using PizzaTime.Core.PointOfSaleMachine.CashRegister;
    using PizzaTime.Core.PointOfSaleMachine.CashRegister.CashDrawer;
    using PizzaTime.Core.PointOfSaleMachine.Customer;
    using PizzaTime.Core.PointOfSaleMachine.Order;
    using PizzaTime.Core.PointOfSaleMachine.Printer;
    using PizzaTime.Core.PointOfSaleMachine.Requests;
    using Shouldly;
    using System;

    [TestClass]
    public class InsertCashDrawerTests
    {
        ICashRegister cashRegister;

        [TestInitialize]
        public void Initialize()
        {
            cashRegister = new CashRegister();
        }

        [TestMethod]
        public void InsertCashDrawer_SetsIsOpenToFalse()
        {
            var cashDrawer = A.Fake<ICashDrawer>();
            cashRegister.InsertCashDrawer(cashDrawer);
            cashRegister.IsOpen.ShouldBeFalse();
        }
    }
}
