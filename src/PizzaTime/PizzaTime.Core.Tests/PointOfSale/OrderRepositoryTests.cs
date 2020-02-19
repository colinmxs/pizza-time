namespace PizzaTime.Core.Tests.PointOfSale
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PizzaTime.Core.Orders;
    using PizzaTime.Core.PointOfSale;
    using Shouldly;
    using System.Linq;

    [TestClass]
    public class OrderRepositoryTests
    {
        IOrderRepository orderRepository = new OrderRepository();

        [TestMethod]
        public void HappyPath()
        {
            for (int i = 0; i < 30; i++)
            {
                var order = new Order(Order.OrderType.DineIn);
                orderRepository.Add(order);
            }           

            var results = orderRepository.GetOrders(page: 0);
            results.Count().ShouldBe(10);

            var result2 = orderRepository.GetOrders(1);
            results.ShouldNotContain(result2.First());
        }
    }
}
