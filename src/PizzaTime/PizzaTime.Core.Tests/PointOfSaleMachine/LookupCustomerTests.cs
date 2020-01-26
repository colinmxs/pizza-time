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
    public class LookupCustomerTests
    {
        PointOfSaleMachine pointOfSaleMachine;
        string lookupNumber;

        [TestInitialize]
        public void Initialize()
        {
            var random = new Random();
            lookupNumber = random.Next(1000000000, 1999999999).ToString();
            var customerRepo = A.Fake<ICustomerRepository>();            
            A.CallTo(() => customerRepo.GetByPhoneNumber(A<string>.That.Matches(s => s == lookupNumber)))
                .Returns(A.Fake<Customer>());

            A.CallTo(() => customerRepo.GetByPhoneNumber(A<string>.That.Matches(s => s != lookupNumber)))
                .Returns(null);

            pointOfSaleMachine = new PointOfSaleMachine(
                A.Fake<ICashRegister>(),
                customerRepo,
                A.Fake<IOrderRepository>(),
                A.Fake<IPrinter>());
        }

        [TestMethod]
        public void LookupCustomer_ReturnsCustomerIfTheyExist()
        {
            //arrange
            var lookupCustomerRequest = new LookupCustomerRequest()
            {
                PhoneNumber = lookupNumber
            };

            //act
            var result = pointOfSaleMachine.LookupCustomer(lookupCustomerRequest);

            //assert
            result.Success.ShouldBeTrue();
            result.Customer.ShouldNotBeNull();
        }

        [TestMethod]
        public void LookupCustomer_ReturnsNullIfTheyDontExist()
        {
            //arrange
            var lookupCustomerRequest = new LookupCustomerRequest()
            {
                PhoneNumber = "sdfsdf"
            };

            //act
            var result = pointOfSaleMachine.LookupCustomer(lookupCustomerRequest);

            //assert
            result.Success.ShouldBeTrue();
            result.Customer.ShouldBeNull();
        }
    }
}
