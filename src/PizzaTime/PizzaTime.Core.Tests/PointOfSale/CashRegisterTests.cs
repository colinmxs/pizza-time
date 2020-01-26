namespace PizzaTime.Core.Tests.PointOfSale
{
    using FakeItEasy;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PizzaTime.Core.PointOfSale;
    using Shouldly;
    using System;

    [TestClass]
    public class CashRegisterTests
    {
        ICashRegister cashRegister;

        [TestInitialize]
        public void Initialize()
        {
            cashRegister = new CashRegister(A.Fake<ICashDrawer>());
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
        
        [TestMethod]
        public void InsertCashDrawer_SetsIsOpenToFalse()
        {
            var cashDrawer = A.Fake<ICashDrawer>();
            cashRegister.InsertCashDrawer(cashDrawer);
            cashRegister.IsOpen.ShouldBeFalse();
        }
    }
}
