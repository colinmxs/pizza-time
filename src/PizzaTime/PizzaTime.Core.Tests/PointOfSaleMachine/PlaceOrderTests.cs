namespace PizzaTime.Core.Tests.PointOfSaleMachine
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
    using System.Collections.Generic;

    [TestClass]
    public class PlaceOrderTests
    {
        PointOfSaleMachine pointOfSaleMachine;
        IOrderRepository orderRepo = A.Fake<IOrderRepository>();
        IPrinter printer = A.Fake<IPrinter>();
        ICashRegister cashRegister = A.Fake<ICashRegister>();

        [TestInitialize]
        public void Initilialize()
        {
            A.CallTo(() => orderRepo.Add(A<Order>._)).Returns(true);
            A.CallTo(() => printer.PrintTickets(A<Order>._)).Returns(new Ticket[1]);
            A.CallTo(() => cashRegister.EjectCashDrawer()).Returns(A.Fake<ICashDrawer>());

            pointOfSaleMachine = new PointOfSaleMachine(
                cashRegister,
                A.Fake<ICustomerRepository>(),
                orderRepo,
                printer);
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
    }
}
