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
    public class AddOrUpdateCustomerTests
    {
        PointOfSaleMachine pointOfSaleMachine;
        Customer knownCustomer;
        ICustomerRepository customerRepo;

        [TestInitialize]
        public void Initialize()
        {
            knownCustomer = new Customer("Dan", "Brown", "0987654321");
            customerRepo = A.Fake<ICustomerRepository>();
            
            A.CallTo(() => customerRepo.GetById(A<Guid>.That.Matches(g => g == knownCustomer.Id)))
                .Returns(knownCustomer);

            A.CallTo(() => customerRepo.GetById(A<Guid>.That.Matches(g => g != knownCustomer.Id)))
                .Returns(null);

            pointOfSaleMachine = new PointOfSaleMachine(
                A.Fake<ICashRegister>(),
                customerRepo,
                A.Fake<IOrderRepository>(),
                A.Fake<IPrinter>());
        }

        [TestMethod]
        public void AddOrUpdateCustomer_FailsOnNullPhoneNumber()
        {
            //arrange
            var customer = new Customer("David", "Jones", null);
            var addOrUpdateCustomerRequest = new AddOrUpdateCustomerRequest
            {
                Customer = customer
            };

            //act
            var result = pointOfSaleMachine.AddOrUpdateCustomer(addOrUpdateCustomerRequest);

            //assert
            result.Success.ShouldBeFalse();
            result.Customer.ShouldBe(customer);
        }

        [TestMethod]
        public void AddOrUpdateCustomer_FailsOnNullName()
        {
            //arrange
            var customer = new Customer(null, null, "1234567890");
            var addOrUpdateCustomerRequest = new AddOrUpdateCustomerRequest
            {
                Customer = customer
            };

            //act
            var result = pointOfSaleMachine.AddOrUpdateCustomer(addOrUpdateCustomerRequest);

            //assert
            result.Success.ShouldBeFalse();
            result.Customer.ShouldBe(customer);
        }

        [TestMethod]
        public void AddOrUpdateCustomer_AddsCustomer()
        {
            //arrange
            var customer = new Customer("David", "Jones", "1234567890");
            var addOrUpdateCustomerRequest = new AddOrUpdateCustomerRequest
            {
                Customer = customer
            };

            //act
            var result = pointOfSaleMachine.AddOrUpdateCustomer(addOrUpdateCustomerRequest);

            //assert
            result.Success.ShouldBeTrue();
            result.Customer.ShouldBe(customer);
        }

        [TestMethod]
        public void AddOrUpdateCustomer_UpdatesCustomer()
        {
            //arrange
            var customer = knownCustomer;
            customer.FirstName = "Davy";
            customer.LastName = "Gravy";
            customer.PhoneNumber = "9998887777";
            var addOrUpdateCustomerRequest = new AddOrUpdateCustomerRequest
            {
                Customer = customer
            };

            //act
            var result = pointOfSaleMachine.AddOrUpdateCustomer(addOrUpdateCustomerRequest);

            //assert
            result.Success.ShouldBeTrue();
            result.Customer.ShouldBe(customer);
            A.CallTo(() => customerRepo.Remove(A<Customer>.That.Matches(c => c.Id == knownCustomer.Id))).MustHaveHappened();
        }
    }
}
