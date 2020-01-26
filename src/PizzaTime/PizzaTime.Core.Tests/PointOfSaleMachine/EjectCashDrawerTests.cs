namespace PizzaTime.Core.Tests.PointOfSaleMachine
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
        PointOfSaleMachine pointOfSaleMachine;
        ICashRegister cashRegister = A.Fake<ICashRegister>();

        [TestInitialize]
        public void Initialize()
        {
            pointOfSaleMachine = new PointOfSaleMachine(
                cashRegister,
                A.Fake<ICustomerRepository>(),
                A.Fake<IOrderRepository>(),
                A.Fake<IPrinter>());
        }

        [TestMethod]
        public void EjectCashDrawer_SucceedsWithCorrectPasscode()
        {
            //arrange
            var request = new EjectCashDrawerRequest()
            {
                Passcode = "admin"
            };

            //act
            var result = pointOfSaleMachine.EjectCashDrawer(request);

            //assert
            result.Success.ShouldBeTrue();
        }

        [TestMethod]
        public void EjectCashDrawer_FailsWithIncorrectPasscode()
        {
            //arrange
            var request = new EjectCashDrawerRequest()
            {
                Passcode = "asdf"
            };

            //act
            var result = pointOfSaleMachine.EjectCashDrawer(request);

            //assert
            result.Success.ShouldBeFalse();
        }

        [TestMethod]
        public void EjectCashDrawer_ReturnsCashDrawerOnSuccess()
        {
            //arrange
            var request = new EjectCashDrawerRequest()
            {
                Passcode = "admin"
            };

            //act
            var result = pointOfSaleMachine.EjectCashDrawer(request);

            //assert
            result.CashDrawer.ShouldNotBeNull();            
        }
    }
}
