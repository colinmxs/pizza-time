namespace PizzaTime.Core.Tests.PointOfSale
{
    using FakeItEasy;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PizzaTime.Core.PointOfSale;
    using PizzaTime.Core.PointOfSale.Requests;
    using Shouldly;
    using System;
    using static PizzaTime.Core.PointOfSale.Order;

    [TestClass]
    public class PointOfSaleMachineTests
    {
        PointOfSaleMachine pointOfSaleMachine;
        IOrderRepository orderRepo = A.Fake<IOrderRepository>();
        IPrinter printer = A.Fake<IPrinter>();
        ICashRegister cashRegister = A.Fake<ICashRegister>();
        ICustomerRepository customerRepo = A.Fake<ICustomerRepository>();
        Customer knownCustomer;
        string lookupNumber;

        [TestInitialize]
        public void Initilialize()
        {
            A.CallTo(() => orderRepo.Add(A<Order>._)).Returns(true);
            A.CallTo(() => printer.PrintTickets(A<Order>._)).Returns(new Ticket[1]);
            A.CallTo(() => cashRegister.EjectCashDrawer()).Returns(A.Fake<ICashDrawer>());

            var random = new Random();
            lookupNumber = random.Next(1000000000, 1999999999).ToString();
            A.CallTo(() => customerRepo.GetByPhoneNumber(A<string>.That.Matches(s => s == lookupNumber)))
                .Returns(A.Fake<Customer>());

            A.CallTo(() => customerRepo.GetByPhoneNumber(A<string>.That.Matches(s => s != lookupNumber)))
                .Returns(null);

            knownCustomer = new Customer("Dan", "Brown", "0987654321");            

            A.CallTo(() => customerRepo.GetById(A<Guid>.That.Matches(g => g == knownCustomer.Id)))
                .Returns(knownCustomer);

            A.CallTo(() => customerRepo.GetById(A<Guid>.That.Matches(g => g != knownCustomer.Id)))
                .Returns(null);

            pointOfSaleMachine = new PointOfSaleMachine(
                cashRegister,
                customerRepo,
                orderRepo,
                printer);
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

        [TestMethod]
        public void PlaceOrder_AddsOrder()
        {
            //arrange
            var order = new Order(OrderType.DineIn)
            {
                OrderItems = new OrderItem[]
                {
                    new OrderItem()
                }
            };

            var placeOrderRequest = new PlaceOrderRequest
            {
                Order = order
            };

            //act
            var result = pointOfSaleMachine.PlaceOrder(placeOrderRequest);

            //assert
            result.Success.ShouldBeTrue();
            result.Order.ShouldBe(order);
            A.CallTo(() => orderRepo.Add(A<Order>.That.Matches(o => o == order))).MustHaveHappened();
        }

        [TestMethod]
        public void PlaceOrder_PrintsTickets()
        {
            //arrange
            var order = new Order(OrderType.DineIn)
            {
                OrderItems = new OrderItem[]
                {
                    new OrderItem()
                }
            };

            var placeOrderRequest = new PlaceOrderRequest
            {
                Order = order
            };

            //act
            var result = pointOfSaleMachine.PlaceOrder(placeOrderRequest);

            //assert
            result.Success.ShouldBeTrue();
            result.Tickets.ShouldNotBeNull();
            A.CallTo(() => printer.PrintTickets(A<Order>.That.Matches(o => o == order))).MustHaveHappened();
        }

        [TestMethod]
        public void PlaceOrder_OpensCashDrawer()
        {
            //arrange
            var order = new Order(OrderType.DineIn)
            {
                OrderItems = new OrderItem[]
                {
                    new OrderItem()
                }
            };

            var placeOrderRequest = new PlaceOrderRequest
            {
                Order = order
            };

            //act
            var result = pointOfSaleMachine.PlaceOrder(placeOrderRequest);

            //assert
            result.Success.ShouldBeTrue();
            result.CashDrawer.ShouldNotBeNull();
            A.CallTo(() => cashRegister.EjectCashDrawer()).MustHaveHappened();
        }

        [TestMethod]
        public void PlaceOrder_FailsOnNullOrEmptyOrderItems()
        {
            //arrange
            var order = new Order(OrderType.DineIn)
            {
                OrderItems = null
            };

            var placeOrderRequest = new PlaceOrderRequest
            {
                Order = order
            };

            //act
            var result = pointOfSaleMachine.PlaceOrder(placeOrderRequest);

            //assert
            result.Success.ShouldBeFalse();
            A.CallTo(() => cashRegister.EjectCashDrawer()).MustNotHaveHappened();
            A.CallTo(() => printer.PrintTickets(A<Order>._)).MustNotHaveHappened();
        }

        [TestMethod]
        public void PlaceOrder_FailsOnNullCustomerForDeliveryOrderType()
        {
            //arrange
            var order = new Order(OrderType.Delivery)
            {
                OrderItems = new OrderItem[]
                {
                    new OrderItem()
                },
                Customer = null
            };

            var placeOrderRequest = new PlaceOrderRequest
            {
                Order = order
            };

            //act
            var result = pointOfSaleMachine.PlaceOrder(placeOrderRequest);

            //assert
            result.Success.ShouldBeFalse();
            A.CallTo(() => cashRegister.EjectCashDrawer()).MustNotHaveHappened();
            A.CallTo(() => printer.PrintTickets(A<Order>._)).MustNotHaveHappened();
        }

        [TestMethod]
        public void PlaceOrder_FailsOnNullCustomerForTakeOutOrderType()
        {
            //arrange
            var order = new Order(OrderType.TakeOut)
            {
                OrderItems = new OrderItem[]
                {
                    new OrderItem()
                },
                Customer = null
            };

            var placeOrderRequest = new PlaceOrderRequest
            {
                Order = order
            };

            //act
            var result = pointOfSaleMachine.PlaceOrder(placeOrderRequest);

            //assert
            result.Success.ShouldBeFalse();
            A.CallTo(() => cashRegister.EjectCashDrawer()).MustNotHaveHappened();
            A.CallTo(() => printer.PrintTickets(A<Order>._)).MustNotHaveHappened();
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
