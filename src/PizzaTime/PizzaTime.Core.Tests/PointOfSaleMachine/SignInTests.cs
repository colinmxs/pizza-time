namespace PizzaTime.Core.Tests.PointOfSaleMachine
{
    using FakeItEasy;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PizzaTime.Core.PointOfSaleMachine;
    using PizzaTime.Core.PointOfSaleMachine.CashRegister;
    using PizzaTime.Core.PointOfSaleMachine.Customer;
    using PizzaTime.Core.PointOfSaleMachine.Order;
    using PizzaTime.Core.PointOfSaleMachine.Printer;
    using Shouldly;

    [TestClass]
    public class SignInTests
    {
        PointOfSaleMachine pointOfSaleMachine;

        [TestInitialize]
        public void Initialize()
        {
            pointOfSaleMachine = new PointOfSaleMachine(
                A.Fake<ICashRegister>(),
                A.Fake<ICustomerRepository>(),
                A.Fake<IOrderRepository>(),
                A.Fake<IPrinter>());
        }

        [TestMethod]
        public void SignIn_IsSuccessfulWithProperCredentials()
        {
            //arrange
            var signInRequest = new SignInRequest()
            {
                Passcode = "admin"
            };

            //act
            var result = pointOfSaleMachine.SignIn(signInRequest);

            //assert
            result.Success.ShouldBeTrue();
        }

        [TestMethod]
        public void SignIn_FailsWithoutProperCredentials()
        {
            //arrange
            var signInRequest = new SignInRequest()
            {
                Passcode = "password"
            };

            //act
            var result = pointOfSaleMachine.SignIn(signInRequest);

            //assert
            result.Success.ShouldBeFalse();
        }
    }
}
